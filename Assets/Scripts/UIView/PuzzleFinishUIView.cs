using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PuzzleFinishUiView : MonoBehaviour
{
    [SerializeField] private GameObject UIParent; // Parent object holding the UI

    private void Awake()
    {
        UIParent.SetActive(false);
    }

    public void Finish()
    {
        UIParent.SetActive(true);
    }

    public void Restart()
    {
        UIParent.SetActive(false);
    }
}
