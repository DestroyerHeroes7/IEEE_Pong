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

    public GameObject powerUpPrefab;

    public float powerUpXBound;
    public float powerUpYBound;

    public Player player1;
    public Player player2;

    public Ball ball;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", 5, 10);
    }
    public void OnScore()
    {
        SetDefault();
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
    public void SetDefault()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("PowerUp"))
            Destroy(g);
        player1.SetDefault();
        player2.SetDefault();
        ball.SetDefault();
        ball.Invoke("Start", 0.5f);
        CancelInvoke("SpawnPowerUp");
        InvokeRepeating("SpawnPowerUp", 5, 10);
    }
    private void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, new Vector3(Random.Range(-powerUpXBound, powerUpXBound), Random.Range(-powerUpYBound, powerUpYBound)), Quaternion.identity);
    }
}
