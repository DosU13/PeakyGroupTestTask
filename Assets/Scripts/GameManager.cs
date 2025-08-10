using System;
using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string PuzzleSceneName;
    public string MainMenuSceneName;
    public bool IsMainScene;

    private bool IsGameOver;
    private PlayerModel playerModel;
    private GameOverUIView gameOverUIView;

    private void Awake()
    {
        playerModel = Resources.FindObjectsOfTypeAll<PlayerModel>().FirstOrDefault();
        gameOverUIView = Resources.FindObjectsOfTypeAll<GameOverUIView>().FirstOrDefault();
    }

    internal void GameOver()
    {
        gameOverUIView.GameOver();
    }

    internal void Win()
    {
        SceneManager.LoadScene(PuzzleSceneName, LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName, LoadSceneMode.Single);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMainScene && IsGameOver is false && playerModel.Alive is false)
        {
            IsGameOver = true;
            GameOver();
        }
    }
}
