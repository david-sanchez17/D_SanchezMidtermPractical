using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 10;

    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private float floatSpeed = 1f;
    [SerializeField] private float floatHeight = 0.5f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        RotateCoin();
        FloatCoin();
    }

    private void RotateCoin()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
    private void FloatCoin()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        Destroy(gameObject);
    }
}
