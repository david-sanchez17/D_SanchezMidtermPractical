using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxObstacles = 10;

    private int currentObstacleCount;
    private bool spawningEnabled = true;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    private void SpawnObstacle()
    {
        if (!spawningEnabled)
        {
            return;
        }

        if(currentObstacleCount >= maxObstacles)
        {
            return;
        }
        if (spawnPoints.Length == 0)
        {
            return;
        }
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
        Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();

        if (obstacleScript != null)
        {
            obstacleScript.SetSpawner(this);
        }
        currentObstacleCount++;
    }

    public void ObstacleDestroyed()
    {
        currentObstacleCount--;

        if (currentObstacleCount <0)
        {
            currentObstacleCount = 0;
        }

        if (spawningEnabled)
        {
            SpawnObstacle();
        }
    }

    public void StopSpawning()
    {
        spawningEnabled = false;
        CancelInvoke();
    }
}
