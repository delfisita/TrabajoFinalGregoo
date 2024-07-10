using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objetivo;       // Referencia al transform del jugador (o auto)
    public Vector3 offset = new Vector3(0f, 3f, -10f);   // Offset de la cámara respecto al jugador

    void Update()
    {
        if (objetivo != null)
        {
            // Obtener la posición deseada de la cámara
            Vector3 posicionDeseada = objetivo.position + offset;

            // Interpolar suavemente la posición de la cámara hacia la posición deseada
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * 5f);
        }
    }
}
