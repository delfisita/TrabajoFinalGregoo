using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wheelController1 : MonoBehaviour
{
    [SerializeField] WheelCollider frontright;
    [SerializeField] WheelCollider frontleft;
    [SerializeField] WheelCollider backright;
    [SerializeField] WheelCollider backleft;

    public float acceleration = 500f;
    public float breakingforce = 300f;
    public float maxturnangle = 15f;

    private float currentacceleration = 0f;
    private float currentbreakforce = 0f;
    private float currentturnangle = 0f;

    public float fallThreshold = -5f; // Altura en la que el nivel se reinicia

    // Configuraciones de estabilización y antivuelco
    private Rigidbody rb;
    private WheelCollider[] wheels;
    public float stability = 0.3f; // Ajusta este valor según sea necesario
    public float stabilizationSpeed = 2.0f; // Ajusta este valor según sea necesario
    public float antiRollForce = 5000.0f; // Ajusta este valor según sea necesario

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0); // Ajusta este valor según sea necesario
        wheels = new WheelCollider[] { frontright, frontleft, backright, backleft };
        AdjustWheelFriction();
    }

    void FixedUpdate()
    {
        currentacceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            currentbreakforce = breakingforce;
        }
        else
        {
            currentbreakforce = 0f;
        }

        frontright.motorTorque = currentacceleration;
        frontleft.motorTorque = currentacceleration;
        frontright.brakeTorque = currentbreakforce;
        frontleft.brakeTorque = currentbreakforce;
        backright.brakeTorque = currentbreakforce;
        backleft.brakeTorque = currentbreakforce;

        currentturnangle = maxturnangle * Input.GetAxis("Horizontal");
        frontleft.steerAngle = currentturnangle;
        frontright.steerAngle = currentturnangle;

        Stabilize();
        AntiRoll();

        if (transform.position.y < fallThreshold)
        {
            RestartLevel();
        }
    }


    void AdjustWheelFriction()
    {
        foreach (WheelCollider wheel in wheels)
        {
            WheelFrictionCurve forwardFriction = wheel.forwardFriction;
            forwardFriction.stiffness = 1.5f; // Ajusta este valor según sea necesario
            wheel.forwardFriction = forwardFriction;

            WheelFrictionCurve sidewaysFriction = wheel.sidewaysFriction;
            sidewaysFriction.stiffness = 2.0f; // Ajusta este valor según sea necesario
            wheel.sidewaysFriction = sidewaysFriction;
        }
    }

    void Stabilize()
    {
        Vector3 predictedUp = Quaternion.AngleAxis(
            rb.angularVelocity.magnitude * Mathf.Rad2Deg * stability / stabilizationSpeed,
            rb.angularVelocity
        ) * transform.up;

        Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
        rb.AddTorque(torqueVector * stabilizationSpeed * stabilizationSpeed);
    }

    void AntiRoll()
    {
        WheelHit wheelHit;

        foreach (WheelCollider wheel in wheels)
        {
            if (wheel.GetGroundHit(out wheelHit))
            {
                float travel = (-wheel.transform.InverseTransformPoint(wheelHit.point).y - wheel.radius) / wheel.suspensionDistance;

                float antiRoll = travel * antiRollForce;
                rb.AddForceAtPosition(wheel.transform.up * -antiRoll, wheel.transform.position);
            }
        }
    }

    void RestartLevel()
    {
        // Opcional: Mostrar efectos de muerte o animaciones aquí

        Invoke("ReloadScene", 1);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
