using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject SpawnerParent;
    [SerializeField] private Block BlockPrefab;

    private Stack<Block> Blocks;
    private Block hookedBlock;

    [Header("Listener Events")]
    [SerializeField] private EventChannel BlockCreateEvent;
    [SerializeField] private EventChannel BlockDropEvent;

    private void Awake()
    {
        Blocks = new Stack<Block>();
    }
    private void OnEnable()
    {
        BlockCreateEvent.OnEventTriggered += CreateBlock;
        BlockDropEvent.OnEventTriggered += DropBlock;
    }
    private void OnDisable()
    {
        BlockCreateEvent.OnEventTriggered -= CreateBlock;
        BlockDropEvent.OnEventTriggered -= DropBlock;
    }
    private void CreateBlock()
    {
        Debug.Log("Create");
        hookedBlock = Instantiate(BlockPrefab, SpawnerParent.transform);
    }

    private void DropBlock()
    {
        hookedBlock.transform.SetParent(transform);
        hookedBlock.Drop();
        Blocks.Push(hookedBlock);
    }
}
