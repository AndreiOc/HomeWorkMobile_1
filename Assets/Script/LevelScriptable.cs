using UnityEngine;

[CreateAssetMenu(fileName ="Level",menuName ="Create")]
public class LevelScriptable : ScriptableObject
{
    //Indici il numero del livello
    public int LevelNumber;
    //l'offset dei blocchi
    public float Width;
    public int SteelBricks;

}
