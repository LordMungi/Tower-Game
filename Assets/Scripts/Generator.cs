using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GeneratorConfig Config;

    [SerializeField] private GameObject SpawnerPoint;
    [SerializeField] private Block BlockPrefab;

    void Update()
    {
    }

    public void CreateBlock()
    {
        Debug.Log("Create");
        Block newBlock = Instantiate(BlockPrefab);
        newBlock.Init(SpawnerPoint.transform.position);
    }
}
