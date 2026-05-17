using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private float SPEED = 1f;

    [Header("Listener Events")]
    [SerializeField] private BlockEventChannel BlockLandEvent;

    Vector3 targetPos;

    private void Awake()
    {
        targetPos = transform.position;
    }

    private void OnEnable()
    {
        BlockLandEvent.OnEventTriggered += SetTargetPositionFromBlock;
    }
    private void OnDisable()
    {
        BlockLandEvent.OnEventTriggered -= SetTargetPositionFromBlock;
    }
    void Update()
    {
        if (targetPos != transform.position)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * SPEED);
        }
    }

    void SetTargetPositionFromBlock(Block b)
    {
        targetPos = transform.position + new Vector3(0, b.transform.lossyScale.y, 0);
    }
}
