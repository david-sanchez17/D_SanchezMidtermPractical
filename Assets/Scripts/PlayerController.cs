using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 7f;

    //References
    [SerializeField] private Transform cameraTransform;

    private Rigidbody rb;

    private bool isGrounded = true;
    private bool canMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //Prevent the player from tipping
        rb.freezeRotation = true;
    }

    private void Update()
    {
        if (!canMove)
            return;

        HandleJump();
    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * vertical + right * horizontal).normalized;

        Vector3 velocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);
        rb.linearVelocity = velocity;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    public void DisableMovement()
    {
        canMove = false;
        rb.linearVelocity = Vector3.zero;
    }
}
