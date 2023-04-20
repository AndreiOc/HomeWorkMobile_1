using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speedBall = 200f;
    [SerializeField] private Rigidbody2D _rb2D;

    /// <summary>
    /// da editor non me lo fa inserire
    /// può essere perchè non è un prefab?
    /// </summary>
    [SerializeField] private Paddle _paddle;

    private void Start()
    {
        //Soluzione migliore rispetto a findobject?
        _paddle = transform.parent.GetComponent<Paddle>();
    }

    /// <summary>
    /// Launch Ball 
    /// </summary>
    public void LaunchBall()
    {
        _rb2D.velocity = new Vector2(UnityEngine.Random.Range(-1.0f,1.0f),
                                    UnityEngine.Random.Range(0.1f, 1.0f)).normalized * _speedBall;
    }

    /// <summary>
    /// Check the collision
    /// if the gameobject collided is the paddle, calculate new direction
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            //position of the paddle, 
            float x = hitFactor(transform.position,
                              collision.transform.position,
                              collision.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 direction = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = direction * _speedBall;
        }
    }

    /// <summary>
    /// Più il colpo si avvicina ai lati della barra più sarà orizzontale, 
    /// mentre più il colpo è centrale più sarà verticale la direzione
    /// </summary>
    /// <param name="ballPositon">trasform position of the paddle</param>
    /// <param name="PaddlePosition">trasform position of the paddle</param>
    /// <param name="PaddleWidth"> paddle width </param>
    /// <returns></returns>
    private float hitFactor(Vector2 ballPositon, Vector2 PaddlePosition, float PaddleWidth)
    {
        return (ballPositon.x - PaddlePosition.x) / PaddleWidth;
    }


}
