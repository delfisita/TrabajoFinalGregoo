using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidadMovimiento = 5f;  // Velocidad de movimiento lateral del jugador
    public float rangoMovimiento = 5f;      // Rango máximo de movimiento lateral del jugador
    public float velocidadGiro = 10f;       // Velocidad de rotación del jugador

    void Update()
    {
        // Movimiento hacia adelante constante
        transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);

        // Movimiento lateral con teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * movimientoHorizontal * velocidadGiro * Time.deltaTime);

        // Limitar el movimiento lateral dentro de un rango
        float xPos = Mathf.Clamp(transform.position.x, -rangoMovimiento, rangoMovimiento);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}

