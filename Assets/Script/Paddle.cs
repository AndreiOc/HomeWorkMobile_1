using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _SpeedMovement = 5;
    [SerializeField] private float _BoundX = 7.5f;

    private bool _isDeatched = false;

    public int _Life = 2;

    [SerializeField] private GameObject _Ball;
    void Start()
    {
        _Ball = Instantiate(_Ball);
        AttachBall();
    }
    /// <summary>
    /// Move the paddle
    /// </summary>
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !_isDeatched)
            StartGame();
        if (Input.GetKey(KeyCode.A) && transform.position.x > -_BoundX)
        {
            transform.position += Vector3.left * _SpeedMovement * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < _BoundX)
        {
            transform.position += Vector3.right * _SpeedMovement * Time.deltaTime;
        }
    }

    /// <summary>
    /// Stick the ball to the paddle
    /// </summary>
    public void AttachBall()
    {
        _Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _Ball.transform.SetParent(transform);
        _Ball.transform.position = new Vector3(transform.position.x, -4.18f, 0);
        _isDeatched = false;

    }
    /// <summary>
    /// Decraesce life, update UI, if life is less than 0 destroy go
    /// </summary>
    public void LoseLife()
    {
        --_Life;
        FindObjectOfType<UiController>().DecreaseLife();
        if (_Life < 0)
            Destroy(gameObject);
    }
    /// <summary>
    /// Detach and launch the ball
    /// </summary>
    private void StartGame()
    {
        transform.DetachChildren();
        _Ball.GetComponent<Ball>().LaunchBall();
        _isDeatched = true;
    }

}
