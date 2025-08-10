using UnityEngine;

public class MazeController : MonoBehaviour
{
    public OriginShiftAlgorithm OriginShiftAlgorithm;
    void Start()
    {
        Debug.Log("MazeController Start");
        OriginShiftAlgorithm.Generate();
    }

    private int shiftCount = 0;
    void FixedUpdate()
    {
        if (shiftCount-- > 0)
        {
            OriginShiftAlgorithm.RandomShift();
        }
    }

    public void RandomShift()
    {
        shiftCount = 100;
    }
}
