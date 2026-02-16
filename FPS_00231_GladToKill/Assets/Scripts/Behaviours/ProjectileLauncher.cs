using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] Raycaster raycaster;
    [SerializeField] LayerMask ignoreLayer;

    public void FireProjectile()
    {
        RaycastHit hitObject = raycaster.FireShot();
        Vector3 direction = hitObject.point - firePoint.position;

        if(hitObject.point == Vector3.zero)
        {
            direction = transform.forward;
        }

        Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        RaycastHit hitObject = raycaster.FireShot();
        Vector3 direction = hitObject.point - firePoint.position;

        Ray ray = new Ray(firePoint.position, direction);

        if(Physics.Raycast(ray, out RaycastHit hit, ignoreLayer))
        {
            Gizmos.DrawSphere(hit.point, 0.25f);
        }


        if (hitObject.point == Vector3.zero)
        {
            Gizmos.DrawLine(firePoint.position, firePoint.position + firePoint.forward * 100);
        }
        else
        {
            Gizmos.DrawLine(firePoint.position, hitObject.point);
        }

        
    }
}
