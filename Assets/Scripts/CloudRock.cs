using UnityEngine;

public class CloudRock : MonoBehaviour
{
    public float moveDistance = 0.5f;
    public float moveSpeed = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offsetX = moveDistance * Mathf.Sin(Time.time * moveSpeed);
        transform.position = startPosition + new Vector3(offsetX, 0f, 0f);
    }
}
