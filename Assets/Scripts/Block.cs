using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] BlockConfig Config;

    private float timer = 0f;

    Rigidbody body;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    public void Init(Vector3 position)
    {
        transform.position = position;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= Config.TimeToFreeze && body.linearVelocity == Vector3.zero && !body.isKinematic)
        {
            Freeze();
        }
    }

    private void Freeze()
    {
        body.isKinematic = true;
        GameManager.instance.BlockFreezeEvent.Invoke();
    }
}
