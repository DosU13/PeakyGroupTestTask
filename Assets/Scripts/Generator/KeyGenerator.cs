using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class KeyGenerator : MonoBehaviour
{
    private KeyModel keyModel;
    private MazeModel mazeModel;
    public GameObject keyPrefab;
    public UnityEvent KeyCollected;

    private void Awake()
    {
        keyModel = Resources.FindObjectsOfTypeAll<KeyModel>().FirstOrDefault();
        mazeModel = Resources.FindObjectsOfTypeAll<MazeModel>().FirstOrDefault();
    }

    void Start()
    {
        for (int i = 0; i < keyModel.keyMaxCount; i++)
        {
            Vector2Int cell = new Vector2Int(
                Random.Range(0, mazeModel.width),
                Random.Range(0, mazeModel.height)
            );

            var pos = new Vector3(cell.x, cell.y, 0f);
            GameObject spike = Instantiate(keyPrefab, pos, Quaternion.identity);

            var keyView = spike.GetComponent<KeyView>();
            keyView.SetTeeth(keyModel.KeyTeeth[i]);
            keyView.KeyCollected = KeyCollected;
        }
    }
}
