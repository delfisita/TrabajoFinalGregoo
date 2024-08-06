using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 10; // Daño que el obstáculo inflige al jugador
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
            // Aplicar daño al jugador
            playerHealth.TakeDamage(damage);
        }
    }
}
