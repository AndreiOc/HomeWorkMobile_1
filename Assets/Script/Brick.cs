using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Brick : MonoBehaviour
{
    public bool _isSpecial;
    public bool _isSteeled;
    public GameObject _PowerUp;

    /// <summary>
    /// Increase score and die
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<UiController>().IncreaseScore(); 
        if(_isSpecial)
        {
            Instantiate(_PowerUp, new Vector3(transform.position.x,transform.position.y), Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
