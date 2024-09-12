using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State 
{
    //create an enum state
    public enum STATE {
        IDLE, PATROL, PURSUE, ATTACK, SLEEP, RUNAWAY
    };

    //to check if the state is exiting, updateing or starting
    public enum EVENT {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;

    float visDist = 10.0f;
    float visAngle = 30.0f;
    float shootDist = 7.0f;

    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
    }

    public virtual void Enter() {
        stage = EVENT.UPDATE;
    }

    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public State Process() 
    {
       switch (stage)
        {
            case EVENT.ENTER:
                Enter();
                return this;
            case EVENT.UPDATE:
                Update();
                return this;
            case EVENT.EXIT:
                Exit();
                return nextState;
        }
        return this;
    }

    public bool CanSeePlayer() {
        Vector3 direction = player.position - npc.transform.position; //Gives the vector from the npc to the player
        float angle = Vector3.Angle(direction, npc.transform.position); //Angle of the line of sight
        if(direction.magnitude < visDist && angle < visAngle)
        {
            return true;
        }
        return false;
    }

    public bool IsPlayerBehind() {
        //Calculate from the back of the chacarter by starting with npc.pos - player pos
        //instead of player.pos - npc.pos
        Vector3 direction = npc.transform.position - player.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < 2 && angle < 30)
        {
            return true;
        }
        
        return false;
    }
    public bool CanAttackPlayer() {
        Vector3 direction = player.position - npc.transform.position; //Gives the vector from the npc to the player
        if (direction.magnitude < shootDist)
        {
            return true;
        }
        return false;
    }
}
