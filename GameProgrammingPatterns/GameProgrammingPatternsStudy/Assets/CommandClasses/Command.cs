using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
   public abstract void Execute(Animator anim, bool forward = true);

}

public class MoveForward : Command
{
    public override void Execute(Animator anim, bool forward = true)
    {
        string tigger = forward ? "isWalking" : "isWalkingR";
        anim.SetTrigger(tigger);
    }
}

public class PerformJump : Command
{
    public override void Execute(Animator anim, bool forward = true)
    {
        string tigger = forward ? "isJumping" : "isJumpingR";
        anim.SetTrigger(tigger);
    }
}

public class PerformPunch : Command
{
    public override void Execute(Animator anim, bool forward = true)
    {
        string tigger = forward ? "isPunching" : "isPunchingR";
        anim.SetTrigger(tigger);
    }
}

public class PerformKick : Command
{
    public override void Execute(Animator anim, bool forward = true)
    {
        string tigger = forward ? "isKicking" : "isKickingR";
        anim.SetTrigger("isKicking");
    }
}

public class DoNothing : Command
{
    public override void Execute(Animator anim, bool forward = true)
    {
       
    }
}