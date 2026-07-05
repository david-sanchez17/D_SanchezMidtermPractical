using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static bool GameOver = false;

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int numberOfObstacles = 5;

    [SerializeField] private float minX = -18f;
    [SerializeField] private float maxX = 18f;
    [SerializeField] private float minZ = -18f;
    [SerializeField] private float maxZ = 18f;
    [SerializeField] private float spawnHeight = 0.5f;
   

   private void Start() 
    {
        GameOver = false;
        SpawnInitialObstacles();
    }

    private void SpawnInitialObstacles()
    {
        if (GameOver)
        {
            return;
        }

        for (int i = 0; i < numberOfObstacles; i++)
        {
            SpawnObstacle();
        }
    }
    private void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), spawnHeight, Random.Range(minZ, maxZ));
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
