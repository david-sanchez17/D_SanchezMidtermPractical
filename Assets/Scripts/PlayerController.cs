using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    //Help management movement
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float rotationSpeed = 10f;

    


    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded = true;
    private bool canMove = true;

   private void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
private void Update()
    {
       if (!canMove)
        {
            return;
        }
        HandleMovementInput();
        HandleJump();
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        MovePlayer();
    }
    private void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        //Ignores cam tilt
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();
        movement = forward * vertical + right * horizontal;

        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }
    }
    private void MovePlayer()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.x = movement.x * moveSpeed;
        velocity.z = movement.z * moveSpeed;

        rb.linearVelocity = velocity;

        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    public void DisableMovement()
    {
        canMove = false;
        rb.linearVelocity = Vector3.zero;
    }
}
