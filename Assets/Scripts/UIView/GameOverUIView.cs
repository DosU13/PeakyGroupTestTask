using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverUIView : MonoBehaviour
{
    [SerializeField] private GameObject UIParent;

    private void Awake()
    {
        UIParent.SetActive(false); // hidden by default
    }

    public void GameOver()
    {
        UIParent.SetActive(true);
    }

    public void Restart()
    {
        UIParent.SetActive(false);
    }

    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu"); // replace with your menu scene name
    }
}
