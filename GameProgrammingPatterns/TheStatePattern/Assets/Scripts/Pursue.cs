using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{
    private const string RUNNING_TRIGGER = "isRunning";
   public Pursue(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
        : base(_npc, _agent, _anim, _player) 
    {
        name = STATE.PURSUE;
        agent.speed = 5;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        anim.SetTrigger(RUNNING_TRIGGER);
        base.Enter();
    }
    public override void Update()
    {
        agent.SetDestination(player.position);
        if(agent.hasPath) { //You need to check if the nav mesh agent has the path already to avoid strange behaviors
            if (CanAttackPlayer())
            {
                nextState = new Attack(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
            else if (!CanSeePlayer()) {
                nextState = new Patrol(npc, agent, anim, player);
                stage = EVENT.EXIT;
            }
        }
    }
    public override void Exit() {
        anim.ResetTrigger(RUNNING_TRIGGER);
        base.Exit();
    }
}
