using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Target
    [SerializeField] private Transform target;

    //Cam settings
    [Header("Camera Settings")]
    [SerializeField] private float distance = 6f;
    [SerializeField] private float mouseSensitivity = 150f;
    [SerializeField] private float minPitch = -30f;
    [SerializeField] private float maxPitch = 60f;

    private float yaw;
    private float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }
    private void LateUpdate()
    {
        if (target == null)
            return;
        HandleCameraRotation();
    }
    private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        transform.position = position;
        transform.rotation = rotation;
    }
}
