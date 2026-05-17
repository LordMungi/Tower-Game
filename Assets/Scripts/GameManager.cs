using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private GameManager() { }
    public static GameManager instance { get; private set; }


    [Header("Broadcast Events")]
    [SerializeField] private EventChannel BlockCreateEvent;
    [SerializeField] private EventChannel BlockDropEvent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

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
