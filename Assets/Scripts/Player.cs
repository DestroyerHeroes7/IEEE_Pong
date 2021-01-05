using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Global.PlayerType playerType;
    void Start()
    {

    }
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
}
