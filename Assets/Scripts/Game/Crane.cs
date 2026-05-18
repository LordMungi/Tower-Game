using UnityEngine;

public class Crane : MonoBehaviour
{
    [SerializeField] private float SPEED = 1f;
    [SerializeField] Material wallMaterial;

    [Header("Listener Events")]
    [SerializeField] private BlockEventChannel BlockPerfectLandEvent;
    [SerializeField] private BlockEventChannel BlockSuccessfulLandEvent;
    [SerializeField] private BlockEventChannel BlockFailedLandEvent;

    Vector3 targetPos;
    Vector3 camOffset;

    private void Awake()
    {
        targetPos = transform.position;
        camOffset = transform.position;
    }

    private void OnEnable()
    {
        BlockPerfectLandEvent.OnEventTriggered += SetTargetPositionFromBlock;
        BlockSuccessfulLandEvent.OnEventTriggered += SetTargetPositionFromBlock;
        BlockFailedLandEvent.OnEventTriggered += SetTargetPositionFromBlock;
    }
    private void OnDisable()
    {
        BlockPerfectLandEvent.OnEventTriggered -= SetTargetPositionFromBlock;
        BlockSuccessfulLandEvent.OnEventTriggered -= SetTargetPositionFromBlock;
        BlockFailedLandEvent.OnEventTriggered -= SetTargetPositionFromBlock;
    }
    void Update()
    {
        if (targetPos != transform.position)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * SPEED);
        }
        wallMaterial.mainTextureOffset = new Vector2(0, transform.position.y) / wallMaterial.mainTextureScale.y;
    }

    void SetTargetPositionFromBlock(Block b)
    {
        targetPos = new Vector3(0, b.transform.position.y, 0) + new Vector3(0, b.size.y / 2, 0) + camOffset;
    }
}
