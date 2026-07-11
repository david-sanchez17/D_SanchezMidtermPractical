using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Coin Value")]
    [SerializeField] private int value = 1;

    [Header("Animation")]
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float bobHeight = 0.25f;
    [SerializeField] private float bobSpeed = 2f;

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
        float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(value);
            Destroy(gameObject);
        }
    }
    public void SetValue(int coinValue)
    {
        value = coinValue;
    }
}
