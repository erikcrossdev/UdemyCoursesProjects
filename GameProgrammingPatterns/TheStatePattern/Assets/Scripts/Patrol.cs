using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    private const string WALKING_TRIGGER = "isWalking";
    int currentIndex = -1; //patrol indexes
    public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PATROL;
        agent.speed = 2;
        agent.isStopped = false; //make the agent move if he is idle
    }

    public override void Enter()
    {
        float lastDist = Mathf.Infinity;
        for (int i = 0; i <GameEnvironment.Singleton.Checkpoints.Count; i++)
        {
            GameObject waypoint = GameEnvironment.Singleton.Checkpoints[i];
            float distance = Vector3.Distance(npc.transform.position, waypoint.transform.position);
            if(distance < lastDist) {
                currentIndex = i - 1; //needs to be -1 since it will go to the current index ++ when Update starts
                lastDist = distance;
            }
        }

        anim.SetTrigger(WALKING_TRIGGER);
        base.Enter();
    }

    public override void Update()
    {
        if (agent.remainingDistance < 1)
        {
            if (currentIndex >= GameEnvironment.Singleton.Checkpoints.Count - 1)
            {
                currentIndex = 0; //back to the beginning to the waypoint list
            }
            else
            {
                currentIndex++;
            }
            agent.SetDestination(GameEnvironment.Singleton.Checkpoints[currentIndex].transform.position);
        }
        if (CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        else if(IsPlayerBehind()) 
        {
            nextState = new Runaway(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }

    }

    public override void Exit()
    {
        anim.ResetTrigger(WALKING_TRIGGER);
        base.Exit();
    }
}
