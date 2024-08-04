using UnityEngine;

public class Playerdisparo : MonoBehaviour
{
    public GameObject projectilePrefab;  // El prefab del proyectil
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
        if (projectilePrefab == null)
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
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("El prefab del proyectil no tiene un componente Rigidbody.");
            return;
        }

        // Aplica fuerza al proyectil en la dirección hacia adelante del firePoint
        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
        Debug.Log("Proyectil disparado.");

        // Destruye el proyectil después de projectileLifetime segundos
        Destroy(projectile, projectileLifetime);
    }
}
