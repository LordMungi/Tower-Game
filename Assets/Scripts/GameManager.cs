using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private GameManager() { }

    public static GameManager instance { get; private set; }

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


    [Header("Broadcast Events")]
    [SerializeField] private EventChannel BlockCreateEvent;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            BlockCreateEvent.RaiseEvent();
    }

    private void MoveCamera(Vector3 position) { }
}
