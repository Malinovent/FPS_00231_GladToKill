using UnityEngine;

public class WaypointVisualizer : MonoBehaviour
{
    [SerializeField] private float maxHeight = 2;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, this.transform.position + Vector3.down * maxHeight);

        Ray ray = new Ray(this.transform.position, Vector3.down * maxHeight);
        if (Physics.Raycast(ray, out RaycastHit hit, maxHeight))
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(hit.point, 0.1f);
            Gizmos.color = Color.green;
        }

        Gizmos.DrawSphere(this.transform.position, 0.25f);
    }
}