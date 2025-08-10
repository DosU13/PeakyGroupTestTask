using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HPUIView : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab; // Prefab with Image component
    private PlayerModel playerModel;
    public float heartWidth = 100;

    private void Awake()
    {
        playerModel = Resources.FindObjectsOfTypeAll<PlayerModel>().FirstOrDefault();
    }

    private int oldHeartCount;
    private void Update()
    {
        if (playerModel == null || heartPrefab == null 
            || oldHeartCount == playerModel.HP) return;
        oldHeartCount = playerModel.HP;

        // Remove all existing hearts
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Add one heart for each HP
        for (int i = 0; i < playerModel.HP; i++)
        {
            var p = new Vector3(transform.position.x + i*heartWidth, transform.position.y, transform.position.z);
            Instantiate(heartPrefab, p, Quaternion.identity, transform);
        }
    }
}
