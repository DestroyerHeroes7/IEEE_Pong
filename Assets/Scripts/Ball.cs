﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody2D; 
    public void Start()
    {
        rigidbody2D.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            if (collision.gameObject.name == "Player 1 Goal")
                LevelManager.Instance.OnPlayer2Score();
            else
                LevelManager.Instance.OnPlayer1Score();
            rigidbody2D.velocity = Vector2.zero;
        }
    }
}
