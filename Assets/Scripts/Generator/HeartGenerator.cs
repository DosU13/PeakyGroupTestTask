using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class HeartGenerator : MonoBehaviour
{
    public UnityEvent KeyCollected;
    public int HeartCount = 1;

    private MazeModel mazeModel;
    public GameObject heartPrefab;

    private void Awake()
    {
        mazeModel = Resources.FindObjectsOfTypeAll<MazeModel>().FirstOrDefault();
    }

    void Start()
    {
        while (HeartCount-- > 0)
        {
            Vector2Int cell = new Vector2Int(
                Random.Range(0, mazeModel.width),
                Random.Range(0, mazeModel.height)
            );

            var pos = new Vector3(cell.x, cell.y, 0f);
            GameObject obj = Instantiate(heartPrefab, pos, Quaternion.identity);
        }
    }
}
