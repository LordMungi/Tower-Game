using UnityEngine;

[CreateAssetMenu(fileName = "BlockConfig", menuName = "Scriptable Objects/BlockConfig")]
public class BlockConfig : ScriptableObject
{
    [field: SerializeField] public float MissFallSpeed = 10f;
    [field: SerializeField] public float RotationMaxAngle = 20f;
}
