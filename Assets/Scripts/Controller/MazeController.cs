using UnityEngine;

public class MazeController : MonoBehaviour
{
    public OriginShiftAlgorithm OriginShiftAlgorithm;
    void Start()
    {
        Debug.Log("MazeController Start");
        OriginShiftAlgorithm.Generate();
    }

    public void RandomShift()
    {
        OriginShiftAlgorithm.AsyncRandomShift();
    }
}
