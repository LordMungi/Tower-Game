using UnityEngine;

public class BezierPath : MonoBehaviour
{
    [SerializeField] private Transform[] ControlPoints;

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            switch (ControlPoints.Length)
            {
                case 2:
                    Gizmos.DrawSphere(ControlPoints[0].position + t * (ControlPoints[1].position - ControlPoints[0].position), 0.25f);
                    break;

                case 3:
                    Gizmos.DrawSphere((1 - t) * ((1 - t) * ControlPoints[0].position + t * ControlPoints[1].position) + t * 
                                     ((1 - t) * ControlPoints[1].position + t * ControlPoints[2].position), 0.25f);
                    break;

                case 4:
                    Gizmos.DrawSphere(Mathf.Pow(1 - t, 3) * ControlPoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * ControlPoints[1].position +
                                      3 * (1 - t) * Mathf.Pow(t, 2) * ControlPoints[2].position + Mathf.Pow(t, 3) * ControlPoints[3].position, 0.25f);
                    break;
                default:
                    break;
            }
        }

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
