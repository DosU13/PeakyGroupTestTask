using System.Linq;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private SpikeModel spikeModel;
    private MazeModel mazeModel;
    public GameObject spikePrefab;

    void Awake()
    {
        spikeModel = Resources.FindObjectsOfTypeAll<SpikeModel>().FirstOrDefault();
        mazeModel = Resources.FindObjectsOfTypeAll<MazeModel>().FirstOrDefault();
    }

    void Start()
    {
        var spikeCount = spikeModel.spikeCount;

        while (spikeCount-- > 0)
        {
            Vector2Int cell = new Vector2Int(
                Random.Range(0, mazeModel.width/2)*2+1,
                Random.Range(0, mazeModel.height/2)*2+1
            );

            var pos = new Vector3(cell.x, cell.y, 0f);
            GameObject spike = Instantiate(spikePrefab, pos, Quaternion.identity);
        }
    }
}
