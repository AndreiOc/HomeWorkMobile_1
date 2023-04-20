using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] private Paddle _Paddle;

    /// <summary>
    /// EveryTime i Trigger this collision, destroy ball, check paddle lives; 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_Paddle._Life > 0)
        {
            _Paddle.AttachBall();
            _Paddle.LoseLife();
        }
        else
        {
            _Paddle.LoseLife();
            Destroy(collision.gameObject);
        }
    }
}
