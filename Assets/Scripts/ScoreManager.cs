using UnityEditor;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Win Condition")]
    [SerializeField] private int winningScore = 50;

    [Header("References")]
    [SerializeField] private CoinSpawner coinSpawner;
    [SerializeField] private ObstacleSpawner obstacleSpawner;

    private int currentScore = 0;
    private bool hasWon = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddScore(int points)
    {
        if (hasWon)
        {
            return;
        }

        currentScore += points;

        Debug.Log("Score: " + currentScore);

        if (currentScore >= winningScore)
        {
            WinGame();
        }
    }


    private void WinGame()
    {
        hasWon = true;

        if (coinSpawner != null)
        {
            coinSpawner.StopSpawning();
        }

        if (obstacleSpawner != null)
        {
            obstacleSpawner.StopSpawning();
        }

        Debug.Log("You win");
    }

    public int GetScore()
    {
        return currentScore;
    }
}