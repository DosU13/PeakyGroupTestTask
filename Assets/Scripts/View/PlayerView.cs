using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private PlayerModel playerModel;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerModel = Resources.FindObjectsOfTypeAll<PlayerModel>().FirstOrDefault();
    }

    void Update()
    {
        // Get movement input (WASD / Arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (playerModel is null || playerModel.Alive is false) return;
        // Move with physics
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
