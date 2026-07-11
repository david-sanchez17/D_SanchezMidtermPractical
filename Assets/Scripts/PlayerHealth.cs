using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Health
    [SerializeField] private int maxHealth = 20;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private CoinSpawner coinSpawner;
    [SerializeField] private ObstacleSpawner obstacleSpawner;

    private int currentHealth;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        if(playerController != null)
        {
            playerController.DisableMovement();
        }
        if (coinSpawner != null)
        {
            coinSpawner.StopSpawning();
        }
        if (obstacleSpawner != null)
        {
            obstacleSpawner.StopSpawning();
        }
        Debug.Log("YOU DIED");
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
