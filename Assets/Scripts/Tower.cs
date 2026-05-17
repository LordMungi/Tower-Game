using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Broadcast Events")]
    [SerializeField] private EventChannel BlockLandEvent;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
    }
}
