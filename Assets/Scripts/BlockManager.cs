using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject SpawnerParent;
    [SerializeField] private Block BlockPrefab;

    private Stack<Block> TowerBlocks;
    private Block hookedBlock;
    private float topBlockCenter;
    private float topBlockWidth;

    [Header("Broadcast Events")]
    [SerializeField] private BlockEventChannel BlockSuccessfulLandEvent;
    [SerializeField] private BlockEventChannel BlockFailedLandEvent;

    [Header("Listener Events")]
    [SerializeField] private EventChannel BlockCreateEvent;
    [SerializeField] private EventChannel BlockDropEvent;
    [SerializeField] private BlockEventChannel BlockLandEvent;

    private void Awake()
    {
        TowerBlocks = new Stack<Block>();
    }
    private void OnEnable()
    {
        BlockCreateEvent.OnEventTriggered += CreateBlock;
        BlockDropEvent.OnEventTriggered += DropBlock;
        BlockLandEvent.OnEventTriggered += LandBlock;
    }
    private void OnDisable()
    {
        BlockCreateEvent.OnEventTriggered -= CreateBlock;
        BlockDropEvent.OnEventTriggered -= DropBlock;
        BlockLandEvent.OnEventTriggered -= LandBlock;
    }
    private void CreateBlock()
    {
        if (!hookedBlock)
            hookedBlock = Instantiate(BlockPrefab, SpawnerParent.transform);
    }

    private void DropBlock()
    {
        if (hookedBlock)
        {
            hookedBlock.transform.SetParent(transform);
            hookedBlock.Drop();
            TowerBlocks.Push(hookedBlock);
            hookedBlock = null;
        }
    }

    private void LandBlock(Block b)
    {
        bool isValidLanding = false;

        b.Freeze();

        if (TowerBlocks.Count <= 1)
            isValidLanding = true;
        else if (Mathf.Abs(topBlockCenter - b.transform.position.x) < topBlockWidth / 2)
            isValidLanding = true;

        if (isValidLanding)
        {
            topBlockCenter = b.transform.position.x;
            topBlockWidth = b.transform.lossyScale.x;
            BlockSuccessfulLandEvent.RaiseEvent(b);
        }
        else
        {
            Destroy(TowerBlocks.Pop().gameObject);
            BlockFailedLandEvent.RaiseEvent(b);
        }
        CreateBlock();
    }
}
