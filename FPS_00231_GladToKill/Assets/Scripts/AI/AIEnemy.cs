using System;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AIBehaviourPatrol patrolBehaviour;
    [SerializeField] private AIBehaviourChase chaseBehaviour;
    [SerializeField] private AISenseHearing hearingSense;

    private AIGruntState currentState;

    void Start()
    {
        patrolBehaviour.Initialize(agent);
        chaseBehaviour.Initialize(agent);

        hearingSense.onPlayerHeard += OnPlayerHeard;
        chaseBehaviour.onTargetLost += OnTargetLost;

        SetState(AIGruntState.PATROL);
    }

    private void OnTargetLost()
    {
        SetState(AIGruntState.PATROL);
    }

    private void OnPlayerHeard(Transform transform)
    {
        SetState(AIGruntState.CHASE);
        chaseBehaviour.EnterState(transform);
    }

    /*
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
    }*/

    void Update()
    {
        UpdateState();
    }


    //Change the state
    //Enter
    private void SetState(AIGruntState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case AIGruntState.PATROL:
                patrolBehaviour.StartPatrol();
                break;
            case AIGruntState.CHASE:                
                break;
            case AIGruntState.ATTACK:
                break;
            case AIGruntState.DIE:
                break;
        }

    }

    private void UpdateState()
    {
        switch (currentState)
        {
            case AIGruntState.PATROL:
                patrolBehaviour.UpdatePatrol();
                hearingSense.UpdateHearing();
                break;
            case AIGruntState.CHASE:
                ChaseBehaviour();
                break;
            case AIGruntState.ATTACK:
                break;
            case AIGruntState.DIE:
                break;
        }
    }

    private void ChaseBehaviour()
    {
        //If close to the player, switch to attack
        chaseBehaviour.UpdateState();
    }

    private void OnDestroy()
    {
        hearingSense.onPlayerHeard -= OnPlayerHeard;
        chaseBehaviour.onTargetLost -= OnTargetLost;
    }

    private enum AIGruntState
    {
        PATROL,
        CHASE,
        ATTACK,
        DIE
    }

}
