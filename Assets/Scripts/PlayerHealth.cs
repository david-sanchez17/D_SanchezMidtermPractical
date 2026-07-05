using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private PlayerController playerController;

  private void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        currentHealth = 0;
        Debug.Log("YOU DIED");
        //Stop player movement
        if (playerController !=null)
        {
            playerController.DisableMovement();
        }

       
    }
  public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
