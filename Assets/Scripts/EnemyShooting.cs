using UnityEngine;

public class EnemyShooting :MonoBehaviour
{
    public GameObject proyectilePrefab;  // El prefab del proyectil
    public Transform firePoint;          // El punto desde el que se dispara el proyectil
    public float projectileForce = 500f; // La fuerza aplicada al proyectil
    public float projectileLifetime = 2f; // Tiempo de vida del proyectil en segundos

    void Update()
    {
        // Detecta la entrada para disparar (espacio en este caso)
        if (Input.GetKeyDown(KeyCode.Space)) // Cambia esto si usas otra tecla o método de disparo
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (proyectilePrefab == null)
        {
            Debug.LogError("Prefab del proyectil no asignado.");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError("FirePoint no asignado.");
            return;
        }

        // Instancia el proyectil en la posición y rotación del firePoint
        GameObject projectile = Instantiate(proyectilePrefab, firePoint.position, firePoint.rotation);
       

  
       
        Destroy(projectile, projectileLifetime);
    }
}
