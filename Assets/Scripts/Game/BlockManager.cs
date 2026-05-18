using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] GameConfig gameConfig;
    [SerializeField] private GameObject SpawnerParent;
    [SerializeField] private Block BlockPrefab;

    private Stack<Block> TowerBlocks;
    private Block hookedBlock;
    private float topBlockCenter;
    private float topBlockWidth;

    private Vector3[] WobblePoints;
    private int goingToPointIndex = 0;
    private float wobbleIntensity = 1;

    [Header("Sounds")]
    [SerializeField] private AudioSource BlockLandSFX;
    [SerializeField] private AudioSource BlockPerfectSFX;
    [SerializeField] private AudioSource BlockFailSFX;
    [SerializeField] private AudioSource BlockMissSFX;

    [Header("Broadcast Events")]
    [SerializeField] private BlockEventChannel BlockSuccessfulLandEvent;
    [SerializeField] private BlockEventChannel BlockPerfectLandEvent;
    [SerializeField] private BlockEventChannel BlockFailedLandEvent;
    [SerializeField] private BlockEventChannel BlockMissedLandEvent;

    [Header("Listener Events")]
    [SerializeField] private EventChannel BlockCreateEvent;
    [SerializeField] private EventChannel BlockDropEvent;
    [SerializeField] private BlockEventChannel BlockLandEvent;

    private void Awake()
    {
        TowerBlocks = new Stack<Block>();
        WobblePoints = new Vector3[2];
        WobblePoints[0] = Vector3.zero;
        WobblePoints[1] = Vector3.zero;
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

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, WobblePoints[goingToPointIndex], Time.deltaTime * gameConfig.TowerWobbleSpeed);
        if (transform.position.x == WobblePoints[goingToPointIndex].x)
            goingToPointIndex = goingToPointIndex == 0 ? 1 : 0;
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
        float offset = Mathf.Abs(topBlockCenter - b.transform.position.x);

        WobblePoints[0].x = wobbleIntensity;
        WobblePoints[1].x = -wobbleIntensity;

        if (TowerBlocks.Count <= 1)
        {
            b.Freeze();
            topBlockCenter = b.transform.position.x;
            topBlockWidth = b.transform.lossyScale.x;
            BlockSuccessfulLandEvent.RaiseEvent(b);
            BlockLandSFX.Play();
        }
        else if (offset < gameConfig.PerfectOffset)
        {
            b.Freeze();
            b.transform.position = new Vector3(topBlockCenter, b.transform.position.y, b.transform.position.z);
            topBlockCenter = b.transform.position.x;
            topBlockWidth = b.transform.lossyScale.x;
            BlockPerfectLandEvent.RaiseEvent(b);
            BlockPerfectSFX.Play();
        }
        else if (offset < topBlockWidth / 2)
        {
            b.Freeze();
            topBlockCenter = b.transform.position.x;
            topBlockWidth = b.transform.lossyScale.x;
            BlockSuccessfulLandEvent.RaiseEvent(b);
            BlockLandSFX.Play();
        }
        else if (offset > topBlockWidth)
        {
            b.Fall();
            Destroy(TowerBlocks.Pop().gameObject, 2f);
            BlockMissedLandEvent.RaiseEvent(b);
            BlockMissSFX.Play();
        }
        else
        {
            Destroy(TowerBlocks.Pop().gameObject);
            if (TowerBlocks.Count > 1)
                Destroy(TowerBlocks.Pop().gameObject);
            BlockFailedLandEvent.RaiseEvent(TowerBlocks.Peek());
            BlockFailSFX.Play();
        }
        CreateBlock();
    }
}
