using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GeneratorConfig Config;

    [SerializeField] private GameObject PathObject;
    [SerializeField] private GameObject SpawnerPoint;
    [SerializeField] private Block BlockPrefab;

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
        transform.position = Vector3.MoveTowards(transform.position, PathQueue.Peek().position, Config.Speed * Time.deltaTime);
        if (transform.position == PathQueue.Peek().position)
            PathQueue.Enqueue(PathQueue.Dequeue());
    }

    public void CreateBlock()
    {
        Debug.Log("Create");
        Block newBlock = Instantiate(BlockPrefab);
        newBlock.Init(SpawnerPoint.transform.position);
    }
}
