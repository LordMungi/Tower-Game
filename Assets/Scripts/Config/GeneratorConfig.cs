using UnityEngine;

[CreateAssetMenu(fileName = "GeneratorConfig", menuName = "Scriptable Objects/GeneratorConfig")]
public class GeneratorConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; }
}
