using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    //Coin prefabs
    [SerializeField] private GameObject bronzeCoin;
    [SerializeField] private GameObject silverCoin;
    [SerializeField] private GameObject goldCoin;

    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private int startingCoins = 5;
    [SerializeField] private int maxCoins = 15;

    [SerializeField] private float minX = -18f;
    [SerializeField] private float maxX = 18f;
    [SerializeField] private float minZ = -18f;
    [SerializeField] private float maxZ = -18f;
    [SerializeField] private float coinHeight = 0.5f;

    private bool spawningEnabled = true;

    private void Start()
    {
        for (int i = 0; i< startingCoins; i++)
        {
            SpawnCoin();
        }
        InvokeRepeating(nameof(SpawnCoin), spawnInterval, spawnInterval);
    }

    private void SpawnCoin()
    {
        if (!spawningEnabled)
        {
            return;
        }
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), coinHeight, Random.Range(minZ, maxZ));

        int randomCoin = Random.Range(0, 3);
        GameObject coinToSpawn;
        
        switch (randomCoin)
        {
            case 0:
                coinToSpawn = bronzeCoin;
                break;

            case 1:
                coinToSpawn = silverCoin;
                break;

            default:
                coinToSpawn = goldCoin;
                break;
        }
        Instantiate(coinToSpawn, spawnPosition, coinToSpawn.transform.rotation);
    }

    public void StopSpawning()
    {
        spawningEnabled = false;
        CancelInvoke();
    }
}
