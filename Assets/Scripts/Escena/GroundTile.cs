using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject obstacle2Prefab;
    [SerializeField] GameObject enemyPrefab; 
    [SerializeField] float obstacle2Chance = 0.2f;
   // [SerializeField] float enemySpawnChance = 0.1f; 
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            groundSpawner.SpawnTile(true);
           
        }
    }

    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range(0f, 1f);
        if (random < obstacle2Chance)
        {
            obstacleToSpawn = obstacle2Prefab;
        }

        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnEnemies()
    {
        float random = Random.Range(0f, 1f);
      //  if (random < enemySpawnChance)
        {
            int enemySpawnIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(enemySpawnIndex).transform;

            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform);
        }
    }


}
