using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public enum PlayerType
    {
       Player1,
       Player2
    }
    public static float playerVerticalSpeed  = 5;
    public static int gameEndScore = 3;
    public static Vector3 ballDefaultPosition = Vector3.zero;
    public static Vector3 player1DefaultPosition = new Vector3(-8, 0, 0);
    public static Vector3 player2DefaultPosition = new Vector3(8, 0, 0);
    public static Vector3 playerDefaultScale = new Vector3(0.1f, 0.4f, 1);

    public static Dictionary<PowerUpEnum, float> powerUpLifetime = new Dictionary<PowerUpEnum, float>()
    {
        [PowerUpEnum.BallSlowDown] = 2f,
        [PowerUpEnum.BallSpeedUp] = 1f,
        [PowerUpEnum.PaddleLargeDown] = 5f,
        [PowerUpEnum.PaddleLargeUp] = 5f
    };

}
