using System.Linq;
using UnityEngine;

/// <summary>
/// Whenever Puzzle Scene loaded from editor, there wouldn't be KeyModel, since MainScene didn't run, so this script create it, if it doesn't exist
/// Всякий раз, когда Puzzle Scene загружается из редактора, не будет KeyModel в цене, поскольку MainScene ещё не бфл запущен, поэтому этот скрипт создает ее, смотря на ее существование.
/// </summary>
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
