using System.Collections.Generic;
using UnityEngine;

public class RackSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] RackPrefabs;

    [SerializeField] GameObject firstRack;
    [SerializeField] Renderer firstRackMesh;
    [SerializeField] int racksPerRow = 5;
    [SerializeField] float horizontalSpacing = 1f;
    [SerializeField] float verticalSpacing = 1f;

    private Queue<GameObject> racks;
    private Vector3 rackSize;
    private int row = 0;

    private void Awake()
    {
        racks = new Queue<GameObject>();
        rackSize = firstRackMesh.bounds.size;

        CreateRow(1);
        CreateRow();
    }

    private void OnDrawGizmos()
    {
        if (rackSize == Vector3.zero)
            rackSize = firstRackMesh.bounds.size;
        Vector3 drawPos = firstRack.transform.position + rackSize / 2;

        Gizmos.color = new Color(0, 0, 1, 0.3f);
        for (int i = 1; i < racksPerRow; i++)
        {
            Gizmos.DrawCube( drawPos + new Vector3((rackSize.x + horizontalSpacing) * i, 0, 0), rackSize);
        }
        for (int i = 0; i < racksPerRow; i++)
        {
            Gizmos.DrawCube(drawPos + new Vector3((rackSize.x + horizontalSpacing) * i, (rackSize.y + verticalSpacing), 0), rackSize);
        }
    }
    void CreateRow()
    {
        CreateRow(0);
    }
    void CreateRow(int from)
    {
        for (int i = from; i < racksPerRow; i++)
        {
            GameObject newRack = Instantiate(RackPrefabs[0], firstRack.transform);
            newRack.transform.position += new Vector3((rackSize.x + horizontalSpacing) * i, (rackSize.y + verticalSpacing) * row, 0);
            racks.Enqueue(newRack);
        }
        row++;
    }


}
