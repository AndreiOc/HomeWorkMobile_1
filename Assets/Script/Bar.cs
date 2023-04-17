using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private float _SpeedMovement = 5;
    [SerializeField] private float _BoundX = 7.5f;

    private bool _isDeatched = false;

    public int Life = 2;

    [SerializeField] private GameObject _Ball;
    void Start()
    {
        _Ball = Instantiate(_Ball);
        AttachBall();
    }

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

    public void AttachBall()
    {
        _Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _Ball.transform.SetParent(transform);
        _Ball.transform.position = new Vector3(transform.position.x,-4.18f,0);
        _isDeatched = false;

    }
    public void LoseLife()
    {
        if (Life == 0)
            Destroy(gameObject);
        else
            Life = Life - 1;
    }
    private void StartGame()
    {
        transform.DetachChildren();
        _Ball.GetComponent<Ball>().LaunchBall();
        _isDeatched=true;
    }
}
