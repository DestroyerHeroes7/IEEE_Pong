using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEnum powerUpType;
    private void Start()
    {
        powerUpType = (PowerUpEnum)Random.Range(0, 4);
    }
}
public enum PowerUpEnum
{
    BallSpeedUp,
    BallSlowDown,
    PaddleLargeUp,
    PaddleLargeDown
}
