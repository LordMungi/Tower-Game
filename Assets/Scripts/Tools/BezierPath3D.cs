using UnityEngine;

public class BezierPath3D : MonoBehaviour
{
    [SerializeField] private Transform[] ControlPoints;

    private const float GIZMO_SIZE = 0.05f;

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            Gizmos.DrawSphere(GetPointInCurve(t), GIZMO_SIZE);
        }
    }

    public Vector3 GetPointInCurve(float t)
    {
        switch (ControlPoints.Length)
        {
            case 2:
                return ControlPoints[0].position + t * (ControlPoints[1].position - ControlPoints[0].position);

            case 3:
                return (1 - t) * ((1 - t) * ControlPoints[0].position + t * ControlPoints[1].position) + t *
                ((1 - t) * ControlPoints[1].position + t * ControlPoints[2].position);

            case 4:
                return Mathf.Pow(1 - t, 3) * ControlPoints[0].position + 3 * Mathf.Pow(1 - t, 2) * t * ControlPoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * ControlPoints[2].position + Mathf.Pow(t, 3) * ControlPoints[3].position;

            default:
                break;
        }
        return Vector3.zero;
    }
}
