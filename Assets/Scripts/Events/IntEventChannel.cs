using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IntEventChannel", menuName = "Events/IntEventChannel")]
public class IntEventChannel : ScriptableObject
{
    public UnityAction<int> OnEventTriggered;

    public void RaiseEvent(int arg0)
    {
        OnEventTriggered?.Invoke(arg0);
    }
}
