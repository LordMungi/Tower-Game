using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Broadcast Events")]
    [SerializeField] private EventChannel BlockCreateEvent;
    [SerializeField] private EventChannel BlockDropEvent;

    void Start()
    {
        BlockCreateEvent.RaiseEvent();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            BlockDropEvent.RaiseEvent();
    }
}
