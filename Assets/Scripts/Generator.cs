using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GeneratorConfig Config;

    [SerializeField] private GameObject SpawnerPoint;
    [SerializeField] private Block BlockPrefab;

    [Header("Listener Events")]
    [SerializeField] private EventChannel BlockCreateEvent;

    private void OnEnable()
    {
        BlockCreateEvent.OnEventTriggered += CreateBlock;
    }
    private void OnDisable()
    {
        BlockCreateEvent.OnEventTriggered -= CreateBlock;
    }

    public void CreateBlock()
    {
        Debug.Log("Create");
        Block newBlock = Instantiate(BlockPrefab);
        newBlock.Init(SpawnerPoint.transform.position);
    }
}
