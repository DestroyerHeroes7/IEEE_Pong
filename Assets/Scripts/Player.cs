using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Global.PlayerType playerType;

    public AnimationCurve largeCurve;
    void Update()
    {
        switch (playerType)
        {
            case Global.PlayerType.Player1:
                if (Input.GetKey(KeyCode.S))
                    transform.Translate(Vector2.down * Time.deltaTime * Global.playerVerticalSpeed);
                if (Input.GetKey(KeyCode.W))
                    transform.Translate(Vector2.up * Time.deltaTime * Global.playerVerticalSpeed);
                break;
            case Global.PlayerType.Player2:
                if (Input.GetKey(KeyCode.DownArrow))
                    transform.Translate(Vector2.down * Time.deltaTime * Global.playerVerticalSpeed);
                if (Input.GetKey(KeyCode.UpArrow))
                    transform.Translate(Vector2.up * Time.deltaTime * Global.playerVerticalSpeed);
                break;
        }
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4.2f, 4.2f));
    }
    public void SetDefault()
    {
        transform.position = playerType == Global.PlayerType.Player1 ? Global.player1DefaultPosition : Global.player2DefaultPosition;
        transform.localScale = Global.playerDefaultScale;
    }
    public void OnLargeDown()
    {
        transform.DOScaleY(0.2f, 1f).SetEase(largeCurve);
    }
    public void OnLargeUp()
    {
        transform.DOScaleY(0.8f, 1).SetEase(largeCurve);
    }
    public void OnLargeExpire()
    {
        transform.DOScaleY(0.4f, 1f).SetEase(largeCurve);
    }
}
