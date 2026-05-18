using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] BlockConfig Config;

    [SerializeField] Rigidbody body;
    [SerializeField] Renderer model;
    public Vector3 size;
    private void Awake()
    {
        size = model.bounds.size;
        transform.rotation = Quaternion.Euler(0, Random.Range(-Config.RotationMaxAngle, Config.RotationMaxAngle), 0);
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
