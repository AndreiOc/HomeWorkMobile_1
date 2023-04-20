using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _SpeedMovement = 5f;
    [SerializeField] private float _BoundX = 7.5f;
    [SerializeField] UiController _UiController;
    [SerializeField] private GameObject _Ball;


    private bool _isDeatched = false;

    public int _Life = 2;

    private void Start()
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
    /// Detach and launch the ball
    /// </summary>
    private void StartGame()
    {
        transform.DetachChildren();
        _Ball.GetComponent<Ball>().LaunchBall();
        _isDeatched = true;
    }

    /// <summary>
    /// Stick the ball to the paddle
    /// -4,18f corrisponde alla posizione esatta della pallina sopra il paddle
    /// Valore ottenuto dopo diverse prove, non saprei come farlo in altro modo 
    /// se non inserendolo a mano, ho provato ha lasciare solo setparent, però mi crea problemi
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
        Debug.Log(_Life);
        _UiController.DecreaseLife(_Life);
        if (_Life < 0)
            Destroy(gameObject);
    }


}
