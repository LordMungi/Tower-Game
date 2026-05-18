using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Objects/GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public int InitialLives = 3;
    [field: SerializeField] public int ScoreForFloor = 100;
    [field: SerializeField] public int ScoreForPerfect = 300;

}
