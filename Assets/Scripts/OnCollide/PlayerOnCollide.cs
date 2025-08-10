using System.Linq;
using UnityEngine;

public class PlayerOnCollide : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerModel playerModel;

    private void Awake()
    {
        gameManager = Resources.FindObjectsOfTypeAll<GameManager>().FirstOrDefault();
        playerModel = Resources.FindObjectsOfTypeAll<PlayerModel>().FirstOrDefault();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Debug.Log("Enemy!!!");
                playerModel.Damage();
                break;
            case "Key":
                Debug.Log("Key!!!");
                var keyView = collision.gameObject.GetComponent<KeyView>();
                keyView.Collect();
                break;
            case "Portal":
                gameManager.Win();
                break;
        }
    }
}
