using System.Linq;
using UnityEngine;

public class TestKeyModel : MonoBehaviour
{
    private void Awake()
    {
        var keyModel = Resources.FindObjectsOfTypeAll<KeyModel>().FirstOrDefault();
        if (keyModel == null)
        {
            gameObject.AddComponent<KeyModel>();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
