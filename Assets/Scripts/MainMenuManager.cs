using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string MainSceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayClick()
    {
        SceneManager.LoadScene(MainSceneName, LoadSceneMode.Single);
    }

    public void PlaySmall()
    {
        PlayGame(10);
    }

    public void PlayMedium()
    {
        PlayGame(20);
    }

    public void PlayLarge()
    {
        PlayGame(40);
    }

    private int MazeSize;
    private void PlayGame(int mazeSize)
    {
        GameSessionData.MazeSize = mazeSize;
        GameSessionData.SpikeCount = mazeSize / 5;

        SceneManager.LoadScene(MainSceneName, LoadSceneMode.Single);
    }

    private void OnMainSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        SceneManager.sceneLoaded -= OnMainSceneLoaded;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
