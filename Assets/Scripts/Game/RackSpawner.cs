using System.Collections.Generic;
using UnityEngine;

public class RackSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] RackPrefabs;

    [SerializeField] GameObject firstRack;
    [SerializeField] Renderer firstRackMesh;
    [SerializeField] int racksPerRow = 5;
    [SerializeField] float spacing = 1f;

    private Queue<GameObject> racks;
    private Vector3 rackSize;

    private void Awake()
    {
        racks = new Queue<GameObject>();
        rackSize = firstRackMesh.bounds.size;

        for (int i = 1; i < racksPerRow; i++)
        {
            GameObject newRack = Instantiate(RackPrefabs[0], firstRack.transform);
            newRack.transform.position -= new Vector3((rackSize.x + spacing) * i, 0, 0);
            racks.Enqueue(newRack);
        }
    }

    private void OnDrawGizmos()
    {
        if (rackSize == Vector3.zero)
            rackSize = firstRackMesh.bounds.size;
        Vector3 drawPos = firstRack.transform.position + rackSize / 2;

        for (int i = 1; i < racksPerRow; i++)
        {
            Gizmos.color = new Color(0, 0, 1, 0.3f);
            Gizmos.DrawCube( drawPos - new Vector3((rackSize.x + spacing) * i, 0, 0), rackSize);
        }
    }

    void Update()
    {
        
    }
}
