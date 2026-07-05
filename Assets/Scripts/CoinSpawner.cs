using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static bool GameOver = false;

    [SerializeField] private GameObject[] coinPrefabs;

    [SerializeField] private int startingCoins = 5;
    [SerializeField] private float spawnInterval = 3f;

    [SerializeField] private float minX = -18f;
    [SerializeField] private float maxX = 18f;
    [SerializeField] private float minZ = -18f;
    [SerializeField] private float maxZ = 18f;
    [SerializeField] private float spawnHeight = 1f;


private void Start()
    {
        GameOver = false;
        SpawnStartingCoins();
        StartCoroutine(SpawnCoinsOverTime());
    }
    private void SpawnStartingCoins()
    {
        for (int i = 0; i < startingCoins; i++)
        {
            SpawnCoin();
        }
    }
  
    private IEnumerator SpawnCoinsOverTime()
    {
        while (!GameOver)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        GameObject prefab = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), spawnHeight, Random.Range(minZ, maxZ));
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
