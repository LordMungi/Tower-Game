using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private float SPEED = 10.0f;

    [SerializeField] private GameObject PathObject;
    private Queue<Transform> PathQueue = new Queue<Transform>();

    void Start()
    {
        foreach (Transform child in PathObject.transform)
        {
            PathQueue.Enqueue(child);
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PathQueue.Peek().position, SPEED * Time.deltaTime);
        if (transform.position == PathQueue.Peek().position)
            PathQueue.Enqueue(PathQueue.Dequeue());
    }

    public void CreateBlock()
    {
        Debug.Log("Create");
    }
}
