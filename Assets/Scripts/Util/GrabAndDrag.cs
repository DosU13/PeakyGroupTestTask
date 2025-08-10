using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GrabAndDrag : MonoBehaviour
{
    [Tooltip("Distance at which the object will snap to the answer position.")]
    public float snapDistance = 0.5f;

    public Vector3 AnswerPosition { get; set; }

    private Vector3 offset;
    private Camera cam;
    private bool isDragging;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        // Calculate drag offset
        Vector3 mouseWorldPos = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPos;
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Snap to answer position if close enough
        if (Vector3.Distance(transform.position, AnswerPosition) <= snapDistance)
        {
            transform.position = AnswerPosition;
        }
    }

    public bool IsMatched => transform.position == AnswerPosition;

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = GetMouseWorldPosition();
            transform.position = mouseWorldPos + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreen = Input.mousePosition;
        mouseScreen.z = -cam.transform.position.z; // Ensure correct plane
        return cam.ScreenToWorldPoint(mouseScreen);
    }
}
