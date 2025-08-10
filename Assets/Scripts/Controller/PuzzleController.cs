using UnityEngine;
using UnityEngine.Events;

public class PuzzleController : MonoBehaviour
{
    public UnityEvent PuzzleSolved;
    void Start()
    {
        
    }

    private bool TheEnd;
    void Update()
    {
        if (TheEnd) return;

        var locks = Resources.FindObjectsOfTypeAll<GrabAndDrag>();
        foreach (var l in locks)
        {
            if (l.IsMatched == false)
            {
                return;
            }
        }
        TheEnd = true;
        PuzzleSolved?.Invoke();
    }
}
