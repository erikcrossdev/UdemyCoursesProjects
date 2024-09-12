using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) 
        : base(_npc, _agent, _anim, _player) 
    {
        name = STATE.IDLE;
    }
    public override void Enter()
    {
        base.Enter();
        anim.SetTrigger("isIdle");
    }

    public override void Update()
    {
        if (CanSeePlayer()) {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        
        else if (Random.Range(0, 100) < 10)
        {
            //Update needs to know how to exit a condition
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle"); //Reset the queue and clean animator.
        base.Exit();

    }

}
