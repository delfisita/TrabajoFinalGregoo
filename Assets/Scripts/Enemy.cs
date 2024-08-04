using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 10; // Puntos que se suman al destruir el enemigo

    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba si el enemigo ha colisionado con un proyectil
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            Destroy(collision.gameObject); // Destruye el proyectil
            Destroy(gameObject); // Destruye el enemigo
            GameManager.Instance.AddScore(points); // Llama al método para sumar puntos
        }
    }
}
