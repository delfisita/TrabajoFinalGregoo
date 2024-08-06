using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 10; // Da�o que el obst�culo inflige al jugador
    public PlayerHealth playerHealth; // Referencia al componente PlayerHealth

    private void Start()
    {
        // Buscar el componente PlayerHealth en el jugador
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisiona tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aplicar da�o al jugador
            playerHealth.TakeDamage(damage);
        }
    }
}
