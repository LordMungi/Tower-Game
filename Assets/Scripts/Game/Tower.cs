using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Broadcast Events")]
    [SerializeField] private BlockEventChannel BlockLandEvent;

    [Header("Listener Events")]
    [SerializeField] private BlockEventChannel BlockPerfectLandEvent;
    [SerializeField] private BlockEventChannel BlockSuccessfulLandEvent;
    [SerializeField] private BlockEventChannel BlockFailedLandEvent;
    private void OnEnable()
    {
        BlockPerfectLandEvent.OnEventTriggered += SetColliderPositionFromBlock;
        BlockSuccessfulLandEvent.OnEventTriggered += SetColliderPositionFromBlock;
        BlockFailedLandEvent.OnEventTriggered += SetColliderPositionFromBlock;
    }
    private void OnDisable()
    {
        BlockPerfectLandEvent.OnEventTriggered -= SetColliderPositionFromBlock;
        BlockSuccessfulLandEvent.OnEventTriggered -= SetColliderPositionFromBlock;
        BlockFailedLandEvent.OnEventTriggered -= SetColliderPositionFromBlock;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("A!");
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
