using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Salud m�xima del jugador
    private int currentHealth; // Salud actual del jugador
    public int obstacleDamage = 10; // Da�o recibido al colisionar con obst�culos

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud actual al m�ximo
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Reducir la salud actual
        if (currentHealth <= 0)
        {
            Die(); // Llamar al m�todo Die si la salud es 0 o menos
        }
    }

    void Die()
    {
        // Cargar la escena de Game Over
        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisiona tiene el tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Aplicar da�o al jugador
            TakeDamage(obstacleDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto con el que colisiona tiene el tag "Player"
        if (other.CompareTag("Enemyproyectile"))
        {
            // Obtener el da�o del proyectil enemigo
            EnemyProjectile projectile = other.GetComponent<EnemyProjectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.damage);
            }
            Destroy(other.gameObject); // Destruir el proyectil despu�s de hacer da�o
        }
    }
}
