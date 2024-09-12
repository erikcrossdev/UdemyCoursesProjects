using UnityEngine;
using UnityEngine.AI;

internal class Runaway : State
{

    private const string IS_RUNNING = "isRunning";
    public Runaway(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) 
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.RUNAWAY;
        
    }

    public override void Enter()
    {
        anim.SetTrigger(IS_RUNNING);
        agent.isStopped = false;
        agent.speed = 6;
        agent.SetDestination(GameEnvironment.Singleton.SafeLocation.transform.position);
        base.Enter(); 
    }

    public override void Update()
    {
        if (agent.remainingDistance < 1) 
        {
            nextState = new Idle(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }


    public override void Exit()
    {
        anim.ResetTrigger(IS_RUNNING);
        base.Exit();
    }
}