using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private GameManager() { }

    private static GameManager instance;

    private static readonly object _lock = new object();
    
    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
            }
        }
        return instance;
    }

    public UnityEvent BlockCreateEvent;
    public UnityEvent BlockFreezeEvent;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            BlockCreateEvent.Invoke();
    }

    private void MoveCamera(Vector3 position) { }
}
