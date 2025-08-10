using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
    public float rotationSpeed = 90f; // degrees per second

    void Update()
    {
        // Negative angle for clockwise rotation in Unity's coordinate system
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
    }
}
