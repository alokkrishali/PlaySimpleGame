using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;


    public delegate void GameState();
    public GameState Menu, Play, GameOver, GameComplete;

    [SerializeField]
    UnityEngine.UI.Text GameText, buttonText;

    [SerializeField]
    GameObject StartButton, QuitButton;

    public bool ISGamePlay = false;

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Menu -= OnMenu;
        Menu += OnMenu;
        Play -= OnPlay;
        Play += OnPlay;
        GameOver -= OnGameOver;
        GameOver += OnGameOver;
        GameComplete -= OnGameComplete;
        GameComplete += OnGameComplete;
        Menu();
    }

    void OnGameOver()
    {
        ISGamePlay = false;
        GameText.text = "GAME OVER...";
        StartButton.SetActive(true);
        buttonText.text = "RESTART";
        QuitButton.SetActive(false);
    }
    void OnGameComplete()
    {
        ISGamePlay = false;
        GameText.text = "GAME COMPLETED...";
        StartButton.SetActive(false);
        QuitButton.SetActive(true);
    }
    void OnMenu()
    {
        ISGamePlay = false;
        GameText.text = " LET'S PLAY";
        StartButton.SetActive(true);
        buttonText.text = "PLAY";
        QuitButton.SetActive(true);
    }
    void OnPlay()
    {
        GameText.text = "";
        ISGamePlay = true;
        StartButton.SetActive(false);
        QuitButton.SetActive(false);
    }

    public void OnStartClick()
    {
        Play();
    }
    public void OnQuitClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    public void ShowScore(int score)
    {
        GameText.text = ""+ score;
    }
}
