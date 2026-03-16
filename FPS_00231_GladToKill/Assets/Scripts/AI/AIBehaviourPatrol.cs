using System;
using UnityEngine;

public class AIBehaviourPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float destinationThreshold;

    private int currentWaypointIndex = 0;
    private Transform currentWaypoint;

    //Callback
    public event Action<Transform> onNewWaypoint;

    private void Start()
    {
        currentWaypoint = waypoints[currentWaypointIndex];
        onNewWaypoint?.Invoke(currentWaypoint);
    }


    public void UpdatePatrol()
    {
        //Check le distance de IA a cible

        float distance = Vector3.Distance(this.transform.position, currentWaypoint.position);

        if(distance <= destinationThreshold)
        {
            NextWaypoint();
        }

    }

    private void NextWaypoint()
    {
        currentWaypointIndex++;

        if(currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }

        currentWaypoint = waypoints[currentWaypointIndex];
        onNewWaypoint?.Invoke(currentWaypoint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(waypoints[0].position, 0.5f);

        Gizmos.color = Color.red;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            Gizmos.DrawWireSphere(waypoints[i + 1].position, 0.25f);
        }

        Gizmos.DrawLine(waypoints[waypoints.Length - 1].position, waypoints[0].position);
    }

}
