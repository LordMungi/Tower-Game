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
        body.isKinematic = true;
    }

    public void Fall()
    {
        body.linearVelocity = new Vector3(0, -Config.MissFallSpeed, 0);
        body.detectCollisions = false;
    }
}
