using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "BlockEventChannel", menuName = "Events/BlockEventChannel")]
public class BlockEventChannel : ScriptableObject
{
    public UnityAction<Block> OnEventTriggered;

    public void RaiseEvent(Block arg0)
    {
        OnEventTriggered?.Invoke(arg0);
    }
}
