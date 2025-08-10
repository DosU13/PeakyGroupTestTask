using UnityEngine;

public class FireTrapView : MonoBehaviour
{
    private GameObject warning;
    private SpriteRenderer warningRenderer;
    private GameObject ball;
    public float warningDuration = 2f;
    public float flickerSpeed = 8f; // flickers per second
    public float ballSpeed = 5f;

    private float timer;
    private bool ballLaunched = false;

    void Start()
    {
        warning = transform.GetChild(0).gameObject;
        warningRenderer = warning.GetComponent<SpriteRenderer>();
        ball = transform.GetChild(1).gameObject;
        ball.SetActive(false);

        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!ballLaunched)
        {
            if (timer < warningDuration)
            {
                // Flicker opacity using sine wave
                float alpha = (Mathf.Sin(Time.time * flickerSpeed * Mathf.PI * 2) + 1f) * 0.5f;
                Color c = warningRenderer.color;
                c.a = alpha;
                warningRenderer.color = c;
            }
            else
            {
                // Switch from warning to ball
                warning.SetActive(false);
                ball.SetActive(true);
                ballLaunched = true;
            }
        }
        else
        {
            // Move the ball forward
            ball.transform.Translate(Vector3.up * ballSpeed * Time.deltaTime, Space.Self);
        }
    }
}
