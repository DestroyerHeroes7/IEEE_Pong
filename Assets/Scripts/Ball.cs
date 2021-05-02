using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;

    public Player lastPlayer;

    Vector2 lastVelocity;

    public void Start()
    {
        rigidbody2D.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5, ForceMode2D.Impulse);
    }
    public void SetDefault()
    {
        transform.position = Global.ballDefaultPosition;
    }
    private void Update()
    {
        lastVelocity = rigidbody2D.velocity;
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
        if (collision.gameObject.CompareTag("Player"))
            lastPlayer = collision.gameObject.GetComponent<Player>();

        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            float speed = lastVelocity.magnitude;
            Vector2 direction = Vector2.Reflect(lastVelocity.normalized, collision.GetContact(0).normal);

            rigidbody2D.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            OnPowerUp(collision.GetComponent<PowerUp>().powerUpType);
            Destroy(collision.gameObject);
        }
    }
    private void OnPowerUp(PowerUpEnum type)
    {
        switch (type)
        {
            case PowerUpEnum.BallSlowDown:
                rigidbody2D.velocity /= 2;
                break;
            case PowerUpEnum.BallSpeedUp:
                rigidbody2D.velocity *= 2;
                break;
            case PowerUpEnum.PaddleLargeDown:
                lastPlayer.OnLargeDown();
                break;
            case PowerUpEnum.PaddleLargeUp:
                lastPlayer.OnLargeUp();
                break;
        }
        StartCoroutine(OnPowerUpExpire(type, lastPlayer));
    }
    private IEnumerator OnPowerUpExpire(PowerUpEnum type,Player player)
    {
        yield return new WaitForSeconds(Global.powerUpLifetime[type]);
        switch (type)
        {
            case PowerUpEnum.BallSlowDown:
                rigidbody2D.velocity *= 2;
                break;
            case PowerUpEnum.BallSpeedUp:
                rigidbody2D.velocity /= 2;
                break;
            case PowerUpEnum.PaddleLargeDown:
                player.OnLargeExpire();
                break;
            case PowerUpEnum.PaddleLargeUp:
                player.OnLargeExpire();
                break;
        }
    }
}
