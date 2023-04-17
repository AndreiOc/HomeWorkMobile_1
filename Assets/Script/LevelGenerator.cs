using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public LevelScriptable Level;
    [SerializeField] private GameObject _Brick;
    [SerializeField] private GameObject _PowerUp;


    private float _red = 0.1f;
    private float _green = 0.1f;
    private float _blue = 0.1f;
    /// <summary>
    /// Start create the level using LevelScriptable ScriptableObject
    /// </summary>
    void Start()
    {
        int random = Random.Range(0, 10);
        Color color;
        for (int i = -5; i < 6; i++)
        {
            for (float j = 3; j > (3 - Level.Width) / 2; j -= 0.5f)
            {
                /*
                 * Instance a new brick
                 * randomly choose if it is special and give me a power-up
                 */
                GameObject instance = Instantiate(_Brick, new Vector3(i, j, 0), Quaternion.identity);
                if (random == Random.Range(0, 10))
                    instance.gameObject.GetComponent<Brick>()._isSpecial = true;

                if (instance.gameObject.GetComponent<Brick>()._isSpecial)
                {
                    color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                    instance.GetComponent<Brick>()._PowerUp = _PowerUp;

                }
                else
                {
                    color = new Color(_red, _green, _blue);
                    _red += 0.1f;
                    _green += 0.1f;
                    _blue += 0.1f;
                }


                instance.transform.SetParent(transform);
                instance.GetComponent<SpriteRenderer>().material.color = color;
            }
            _red = 0.1f;
            _green = 0.1f;
            _blue = 0.1f;
        }
    }

}
