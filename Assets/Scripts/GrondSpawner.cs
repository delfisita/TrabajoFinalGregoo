using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        Transform spawnPointTransform = temp.transform.Find("Spawn point");

        if (spawnPointTransform != null)
        {
            nextSpawnPoint = spawnPointTransform.position;
        }
        else
        {
            Debug.LogError("SpawnPoint not found in the groundTile prefab!");
        }

        if (spawnItems)
        {
             temp.GetComponent<GroundTile>().SpawnObstacle();
        }
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }
}
