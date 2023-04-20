using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiController : MonoBehaviour
{
    [SerializeField] TMP_Text _Score;
    [SerializeField] TMP_Text _Life;
    [SerializeField] TMP_Text _GameOver;


    private int _score = 0;
    //variabile display

    private void Start()
    {
        _GameOver.enabled = false;
    }

    /// <summary>
    /// Function called when I destroy a block
    /// </summary>
    public void IncreaseScore()
    {
        ++_score;
        _Score.text = "Score : " + (_score * 100).ToString("D7");
    }
    /// <summary>
    /// Change life value on the screen
    /// </summary>
    /// <param name="_life">Plyer lives</param>
    public void DecreaseLife(int _life)
    {
        if (_life > -1)
            _Life.text = "Life : " + _life.ToString("D2");
        else
            _GameOver.enabled = true;
    }
}
