using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo;       // Referencia al transform del jugador (o auto)
    public Vector3 offset = new Vector3(0f, 3f, -10f);   // Offset de la c�mara respecto al jugador

    void Update()
    {
        if (objetivo != null)
        {
            // Obtener la posici�n deseada de la c�mara
            Vector3 posicionDeseada = objetivo.position + offset;

            // Interpolar suavemente la posici�n de la c�mara hacia la posici�n deseada
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * 5f);
        }
    }
}
