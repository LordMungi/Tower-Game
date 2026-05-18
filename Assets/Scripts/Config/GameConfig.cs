using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Objects/GameConfig")]
public class GameConfig : ScriptableObject
{
    [field: SerializeField] public int InitialLives = 3;
    [field: SerializeField] public int ScoreForFloor = 100;
    [field: SerializeField] public int ScoreForPerfect = 300;
    [field: SerializeField] public int BlocksCountedForWobble = 5;
    [field: SerializeField] public float PerfectOffset = 0.01f;
    [field: SerializeField] public float TowerMaxWobble = 2f;
    [field: SerializeField] public float MaxWobbleSpeed = 1f;
    [field: SerializeField] public float WobbleScale = 0.2f;


}
