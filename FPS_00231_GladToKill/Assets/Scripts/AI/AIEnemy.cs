using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AIBehaviourPatrol patrolBehaviour;

    private void OnEnable()
    {
        patrolBehaviour.onNewWaypoint += OnNewWaypoint;
    }

    private void OnDisable()
    {
        patrolBehaviour.onNewWaypoint -= OnNewWaypoint;
    }

    private void OnNewWaypoint(Transform transform)
    {
        agent.SetDestination(transform.position);
    }

    void Update()
    {
        patrolBehaviour.UpdatePatrol();
    }
}
