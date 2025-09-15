using UnityEngine;

public class BoatRock : MonoBehaviour
{
    public float rockingAmplitude = 15f;
    public float rockingSpeed = 2f;  

    private float initialRotationZ;

    void Start()
    {
        initialRotationZ = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        float angle = rockingAmplitude * Mathf.Sin(Time.time * rockingSpeed);
        transform.rotation = Quaternion.Euler(0, 0, initialRotationZ + angle);
    }
}
