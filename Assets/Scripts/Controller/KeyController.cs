using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class KeyController : MonoBehaviour
{
    private KeyModel keyModel;
    private MazeModel mazeModel;
    public GameObject keyPrefab;
    public UnityEvent KeyCollected;
    private PortalController portalController;

    private void Awake()
    {
        keyModel = Resources.FindObjectsOfTypeAll<KeyModel>().FirstOrDefault();
        mazeModel = Resources.FindObjectsOfTypeAll<MazeModel>().FirstOrDefault();
        portalController = Resources.FindObjectsOfTypeAll<PortalController>().FirstOrDefault();
    }

    void Start()
    {
        keyCount = keyModel.keyCount;

        for (int i = 0; i < keyModel.keyCount; i++)
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

    private int keyCount;
    public void OnKeyCollected()
    {
        keyCount--;
        if (keyCount == 0)
        {
            portalController.CreatePortal();
        }
    }
}
