using System;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviourChase : MonoBehaviour
{

    [SerializeField] private float chaseSpeed = 5;
    [SerializeField] private float exitRadius = 15;

    private Transform cible = null;
    private NavMeshAgent agent;

    public event Action onTargetLost;

    public void Initialize(NavMeshAgent agent)
    {
        this.agent = agent;
    }

    public void EnterState(Transform cible)
    {
        this.cible = cible;
        agent.speed = chaseSpeed;
        //Modifier la vitesse de l'agent
    }

    public void UpdateState()
    {
        agent.SetDestination(cible.position);

        float distance = Vector3.Distance(this.transform.position, cible.position);
        if(distance >= exitRadius)
        {
            onTargetLost?.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, exitRadius);
    }

}