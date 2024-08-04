using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void FixedUpdate()
    {
        currentacceleration = acceleration * Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.Space))
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
    }
}
