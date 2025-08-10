using UnityEngine;

public class MainCameraView : MonoBehaviour
{
    [Header("Target")]
    public Transform Target;

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 0, -10); 
    public bool smoothFollow = true;
    public float followSpeed = 2f;

    private Vector3 targetPosition;

    void Start()
    {
        // Set initial position
        if (Target != null)
        {
            transform.position = Target.position + offset;
        }
    }

    void Update()
    {
        if (Target == null) return;

        // Calculate target position
        targetPosition = Target.position + offset;

        if (smoothFollow)
        {
            // Smooth following
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                followSpeed * Time.deltaTime
            );
        }
        else
        {
            // Instant following
            transform.position = targetPosition;
        }
    }
}