using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public UIManager uiManager;
    public int player1Score;
    public int player2Score;

    public Transform player1;
    public Transform player2;

    public Ball ball;
    private void Awake()
    {
        Instance = this;
    }
    public void OnScore()
    {
        SetDefaultPosition();
        if (CheckEndGame())
            SceneManager.LoadScene(0);
    }
    public void OnPlayer1Score()
    {
        uiManager.SetPlayer1ScoreText(++player1Score);
        OnScore();
    }
    public void OnPlayer2Score()
    {
        uiManager.SetPlayer2ScoreText(++player2Score);
        OnScore();
    }
    private bool CheckEndGame() => (player1Score >= Global.gameEndScore || player2Score >= Global.gameEndScore);
    public void SetDefaultPosition()
    {
        player1.position = Global.player1DefaultPosition;
        player2.position = Global.player2DefaultPosition;
        ball.transform.position = Global.ballDefaultPosition;
        ball.Invoke("Start", 0.5f);
    }
}
