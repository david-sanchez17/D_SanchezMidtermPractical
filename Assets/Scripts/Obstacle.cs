using System.Runtime.CompilerServices;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float changeDirectionTime = 2f;
    [SerializeField] private float movementRange = 18f;

    [SerializeField] private int damageAmount = 10;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float timer;

  private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        PickNewDirection();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= changeDirectionTime)
        {
            PickNewDirection();
            timer = 0f;
        }

        Move();
    
    }
    private void PickNewDirection()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }

    private void Move()
    {
        Vector3 velocity = moveDirection * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        KeepInsideBounds();

    }

    private void KeepInsideBounds()
    {
        Vector3 pos = transform.position;
        if (pos.x > movementRange || pos.x< -movementRange)
        {
            moveDirection.x = -moveDirection.x;
        }
        if (pos.z > movementRange || pos.z < -movementRange)
        {
            moveDirection.z = -moveDirection.z;
        }
    }
   private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damageAmount);
        }
    }
 
}
