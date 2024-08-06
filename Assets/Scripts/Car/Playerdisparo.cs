using UnityEngine;

public class Playerdisparo : MonoBehaviour
{
    public GameObject projectilePrefab;  
    public Transform firePoint;          
    public float projectileForce = 500f; 
    public float projectileLifetime = 2f; 

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space)) 
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

      
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("El prefab del proyectil no tiene un componente Rigidbody.");
            return;
        }

        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
        Debug.Log("Proyectil disparado.");

        
        Destroy(projectile, projectileLifetime);
    }
}
