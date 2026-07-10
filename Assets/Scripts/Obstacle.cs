using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{
    //Movement
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float movementRange = 18f;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float moveSpeed;
    private int damageAmount;

    private ObstacleSpawner spawner;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.freezeRotation = true;

        moveSpeed = Random.Range(minSpeed, maxSpeed);
        damageAmount = Random.Range(1, 6);

        PickNewDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PickNewDirection()
    {
        moveDirection = Random.insideUnitSphere;
        moveDirection.y = 0f;
        moveDirection.Normalize();
    }

    private void Move()
    {
        rb.linearVelocity = moveDirection * moveSpeed;

        KeepInsideBounds();
    }

    private void KeepInsideBounds()
    {
        Vector3 posiiton = transform.position;
        if (position.x > movementRange || position.x < -movementRange)
        {
            moveDirection.x *= -1;
        }
        if (position.z > movementRange || position.z < -movementRange)
        {
            moveDirection.z *= -1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Obstacle hit: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit!");
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

            if (player !=null)
            {
                player.TakeDamage(damageAmount);
            }

            DestroyObstacle();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyObstacle();
        }
    }
    private void DestroyObstacle()
    {
        if (spawner !=null)
        {
            spawner.ObstacleDestroyed();
        }
        Destroy(gameObject);
    }

    public void SetSpawner(ObstacleSpawner obstacleSpawner)
    {
        spawner = obstacleSpawner;
    }
}
