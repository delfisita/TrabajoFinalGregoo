using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage = 10; // Cantidad de da�o que hace el proyectil
    public  float lifetime = 2f;
    public float speed = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Destruir el proyectil despu�s de hacer da�o
        }
    }
}
