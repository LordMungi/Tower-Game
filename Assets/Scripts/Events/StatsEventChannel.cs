using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StatsEventChannel", menuName = "Events/StatsEventChannel")]
public class StatsEventChannel : ScriptableObject
{
    public UnityAction<Statistics> OnEventTriggered;

    public void RaiseEvent(Statistics arg0)
    {
        OnEventTriggered?.Invoke(arg0);
    }
}
