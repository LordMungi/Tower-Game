using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] BlockConfig Config;

    Rigidbody body;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Drop()
    {
        body.isKinematic = false;
    }

    public void Freeze()
    {
        body.detectCollisions = false;
        body.isKinematic = true;
    }
}
