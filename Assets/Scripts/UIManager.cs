using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text player1ScoreText;
    public Text player2ScoreText;
    private void Awake()
    {
        Instance = this;
    }
    public void SetPlayer1ScoreText(int score)
    {
        player1ScoreText.text = score.ToString();
    }
    public void SetPlayer2ScoreText(int score)
    {
        player2ScoreText.text = score.ToString();
    }
}
