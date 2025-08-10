using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class KeyUIView : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab; 
    private KeyModel keyModel;
    public float keyWidth = 120;

    private void Awake()
    {
        keyModel = Resources.FindObjectsOfTypeAll<KeyModel>().FirstOrDefault();
    }

    private int oldKeyCount;
    private void Update()
    {
        if (keyModel == null || keyPrefab == null
            || oldKeyCount == keyModel.CollectedKeysCount) return;
        oldKeyCount = keyModel.CollectedKeysCount;

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < keyModel.CollectedKeysCount; i++)
        {
            var p = new Vector3(transform.position.x + i * keyWidth, transform.position.y, transform.position.z);
            var key = Instantiate(keyPrefab, p, Quaternion.identity, transform);
        }
    }
}
