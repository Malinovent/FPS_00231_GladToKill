using System;
using UnityEngine;

public class AISenseHearing : MonoBehaviour
{
    [SerializeField] private float hearingRadius = 10;
    [SerializeField] private LayerMask validLayers;

    public event Action<Transform> onPlayerHeard;
    private bool isPlayerHeard = false;

    public void UpdateHearing()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, hearingRadius, validLayers);

        foreach(Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                onPlayerHeard?.Invoke(collider.transform);
                isPlayerHeard = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        /*if(isPlayerHeard)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.yellow;
        }*/

        Gizmos.color = isPlayerHeard ? Color.red : Color.yellow;

        Gizmos.DrawWireSphere(transform.position, hearingRadius);

    }

}
