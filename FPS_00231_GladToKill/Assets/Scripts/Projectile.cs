using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private float explosionRadius = 4;

    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);
        Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, explosionRadius);
    }
}
