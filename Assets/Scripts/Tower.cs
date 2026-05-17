using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Broadcast Events")]
    [SerializeField] private BlockEventChannel BlockLandEvent;

    [Header("Listener Events")]
    [SerializeField] private BlockEventChannel BlockSuccessfulLandEvent;
    private void OnEnable()
    {
        BlockSuccessfulLandEvent.OnEventTriggered += SetColliderPositionFromBlock;
    }
    private void OnDisable()
    {
        BlockSuccessfulLandEvent.OnEventTriggered -= SetColliderPositionFromBlock;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block b))
        {
            BlockLandEvent.RaiseEvent(b);
        }
    }

    private void SetColliderPositionFromBlock(Block b)
    {
        transform.position = b.transform.position + new Vector3(0, b.transform.lossyScale.y / 2, 0);
    }
}
