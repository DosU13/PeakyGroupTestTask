using System.Linq;
using UnityEngine;

public class PlayerOnCollide : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerModel playerModel;
    private AudioSource audioSource;

    [Header("Collision Sounds")]
    public AudioClip enemyHitSound;
    public AudioClip keyCollectSound;
    public AudioClip portalSound;
    public AudioClip heartCollectSound;

    private void Awake()
    {
        gameManager = Resources.FindObjectsOfTypeAll<GameManager>().FirstOrDefault();
        playerModel = Resources.FindObjectsOfTypeAll<PlayerModel>().FirstOrDefault();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                playerModel.Damage();
                PlaySound(enemyHitSound);
                break;

            case "Key":
                var keyView = collision.gameObject.GetComponent<KeyView>();
                keyView.Collect();
                PlaySound(keyCollectSound);
                break;

            case "Portal":
                gameManager.Win();
                PlaySound(portalSound);
                break;

            case "Heart":
                Destroy(collision.gameObject);
                playerModel.Heal();
                PlaySound(heartCollectSound);
                break;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
