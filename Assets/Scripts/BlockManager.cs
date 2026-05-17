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
    [SerializeField] private BlockEventChannel BlockLandEvent;

    private void Awake()
    {
        Blocks = new Stack<Block>();
    }
    private void OnEnable()
    {
        BlockCreateEvent.OnEventTriggered += CreateBlock;
        BlockDropEvent.OnEventTriggered += DropBlock;
        BlockLandEvent.OnEventTriggered += FreezeBlock;
    }
    private void OnDisable()
    {
        BlockCreateEvent.OnEventTriggered -= CreateBlock;
        BlockDropEvent.OnEventTriggered -= DropBlock;
        BlockLandEvent.OnEventTriggered -= FreezeBlock;
    }
    private void CreateBlock()
    {
        hookedBlock = Instantiate(BlockPrefab, SpawnerParent.transform);
    }

    private void DropBlock()
    {
        hookedBlock.transform.SetParent(transform);
        hookedBlock.Drop();
        Blocks.Push(hookedBlock);
    }

    private void FreezeBlock(Block b)
    {
        b.Freeze();
    }
}
