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
    public static float playerVerticalSpeed  = 2;
    public static int gameEndScore = 3;
    public static Vector3 ballDefaultPosition = Vector3.zero;
    public static Vector3 player1DefaultPosition = new Vector3(-8, 0, 0);
    public static Vector3 player2DefaultPosition = new Vector3(8, 0, 0);
}
