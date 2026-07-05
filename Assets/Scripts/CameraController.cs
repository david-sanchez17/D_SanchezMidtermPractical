using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float distance = 6f;
    [SerializeField] private float height = 2f;
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private float minPitch = -30f;
    [SerializeField] private float maxPitch = 70f;
    private float yaw = 0f;
    private float pitch = 20f;

  private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 targetPosition = player.position + Vector3.up * height;
        Vector3 cameraOffset = rotation * new Vector3(0f, 0f, -distance);

        transform.position = targetPosition + cameraOffset;
        transform.LookAt(targetPosition);  
    }
}
