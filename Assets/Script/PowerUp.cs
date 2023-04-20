using UnityEngine;

/// <summary>
/// TODO 
/// </summary>
public class PowerUp : MonoBehaviour
{
    public bool isRocket = false; //press right mouse button shoot
    public bool isMinimized = false; // minimazed paddle
    public bool isMaximized = false; //maximaxed paddle
    public bool isMultiBallsed = false; // x3 number of ball

    private Paddle _paddle;

    private void Start()
    {
        _paddle = FindObjectOfType<Paddle>();   
        int random = Random.Range(0, 4);
        random = 1;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); 
        switch (random)
        {
            case 0:
                isRocket = true;
                spriteRenderer.color = Color.yellow;
            break;
            case 1:
                isMinimized = true;
                spriteRenderer.color = Color.green;    
           break;
            case 2:
                isMaximized = true;
                spriteRenderer.color = Color.blue;
           break;
            case 3:
                isMultiBallsed = true;  
                spriteRenderer.color = Color.red;
           break;
        }
    }
    private void Update()
    {
        ///Posso inserirlo nel trigger del death
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
         * Idea per i potenziamenti
        if (isRocket)
            Debug.Log("Razzi");
        if(isMinimized)
        {
            _paddle.gameObject.transform.localScale = Vector3.one;
        }

        if (isMaximized)
            Debug.Log("Maxi");
        if (isMultiBallsed)
            Debug.Log("Multi");
        */
        Destroy(gameObject);

    }

}
