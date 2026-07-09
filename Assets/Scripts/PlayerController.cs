using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 7f;

    //Ground Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;
    private bool canJump = true;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Prevents player from tipping
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!canMove)
            return;

        CheckGround();

        HandleJump();
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;
        HandleMovement();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = forward * vertical + right * horizontal;

        if (movement.magnitude > 1) 
            movement.Normalize();
        Vector3 velocity = movement * moveSpeed;
        velocity.y = rb.linearVelocity.y;

        rb.linearVelocity = velocity;
    }

    void HandleJump()
    {
        
    }
}
