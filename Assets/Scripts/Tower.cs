using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Broadcast Events")]
    [SerializeField] private BlockEventChannel BlockLandEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block b))
        {
            BlockLandEvent.RaiseEvent(b);
            transform.position = b.transform.position + new Vector3(0, b.transform.lossyScale.y / 2, 0);
        }
    }
}
