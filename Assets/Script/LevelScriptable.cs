using UnityEngine;

[CreateAssetMenu(fileName ="Level",menuName ="Create")]
public class LevelScriptable : ScriptableObject
{
    //Indici il numero del livello
    public int LevelNumber;
    public int SteelBricks;
    
    /// <summary>
    /// Choose the color of the brick
    /// </summary>
    public Color BrickColor;

    /// <summary>
    /// DOMANDA : rendere l array di numero di elementi pari al numero
    /// di linee e poi scegliere il numero di righe, come faccio 
    /// a fari dipendere da editor l'array _Bricklines da _Lines
    /// </summary>
    [Range(0, 7)]
    public int _Lines;
    
    /// <summary>
    /// this is the number of bricks for lines,
    /// if I choose 3 lines of 5 brick, example :
    /// = = = = =
    /// = = = = =
    /// = = = = =
    /// if I choose 3 line of 1 2 3, example :
    ///     =
    ///    = =
    ///   = = =
    /// </summary>
    [Range(0, 11)]
    public int[] _NBricksLine;



}
