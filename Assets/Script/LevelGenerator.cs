using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class LevelGenerator : MonoBehaviour
{
    public LevelScriptable Level;
    [SerializeField] private GameObject _Brick;
    //TODO POWERUP
    //[SerializeField] private GameObject _PowerUp;


    private float _red;
    private float _green;
    private float _blue;
    /// <summary>
    /// Start create the level using LevelScriptable ScriptableObject
    /// </summary>
    void Start()
    {
        //194, 234, 189 <--brick color

        Debug.Log("r: "+ _red + " g:" + _green + " b: " +_blue );
        _red = Level.BrickColor.r;
        _green = Level.BrickColor.g;
        _blue = Level.BrickColor.b;
        CreateLevel();
    }
    /// <summary>
    /// Create a personalized level based on scirptable obejct
    /// 
    /// </summary>
    private void CreateLevel()
    {
        int index = 0;
        bool isLefted = true;
        int offest;
        if (Level._NBricksLine[index] % 2 != 0)
            offest = 0;
        else
            offest = 1;

        ///start from 3 in high
        for (int i = 3; i >(3 - Level._Lines ); --i)
        {
            for(int j = 0; j < Level._NBricksLine[index]; ++j)
            {
                GameObject instance;
                ///if the number of index is odd, the offeset is 0
                if (Level._NBricksLine[index] % 2 != 0)
                {
                    if (isLefted)
                    {
                        instance = Instantiate(_Brick, new Vector3(offest, i, 0), Quaternion.identity);
                        isLefted = false;
                    }
                    else
                    {
                        instance = Instantiate(_Brick, new Vector3((-1) * offest, i, 0), Quaternion.identity);
                        isLefted = true;
                    }
                    if (j % 2 == 0)
                        offest++;
                }
                //else if is pair, the offest is one 
                else
                {
                    if (isLefted)
                    {
                        instance = Instantiate(_Brick, new Vector3(offest, i, 0), Quaternion.identity);
                        isLefted = false;
                    }
                    else
                    {
                        instance = Instantiate(_Brick, new Vector3((-1) * offest, i, 0), Quaternion.identity);
                        isLefted = true;
                    }
                    ///check per non aumetare l'offeset e mantanere la simmetria dell'immagine 
                    if (j % 2 != 0)
                        offest++;
                }
                instance.GetComponent<SpriteRenderer>().material.color = new UnityEngine.Color(_red, _green, _blue);
                instance.transform.SetParent(transform);
                instance.name = i.ToString();
            }
            _red = _red - 0.1f;
            _green = _green - 0.1f;
            _blue = _blue - 0.1f;
            ///increase the index
            ///Chech if it is correct
            ///after check the values of bricks per line and choose the offeset
            ++index;

            if (index == Level._NBricksLine.Length)
                index = 0;

            if (Level._NBricksLine[index] % 2 != 0)
                offest = 0;
            else
                offest = 1;
        }
    }

}
