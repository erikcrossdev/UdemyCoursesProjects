using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private GameObject actor;
    Animator anim;
    Command keyQ, keyW, keyE, upArrow;
    List<Command> oldCommands = new List<Command>();
    [SerializeField] KeyCode keycodeJump, keycodeMove, keycodeKick, keycodeReverse, keycodeReplay, keycodePunch;

    Coroutine replayCoroutine;
    bool shouldStartReplay;
    bool isReplaying;
   
    void Start()
    {
        keyQ = new PerformJump();
        keyW = new PerformKick();
        keyE = new PerformPunch();
        upArrow = new  MoveForward();
        anim = actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }

    void Update()
    {
       if(!isReplaying)
        {
            HandleInput();
        }
        StartReplaying();
    }

    void HandleInput() {
        if (Input.GetKeyDown(keycodeJump))
        {
            keyQ.Execute(anim);
            oldCommands.Add(keyQ);
        }
        else if (Input.GetKeyDown(keycodeKick))
        {
            keyW.Execute(anim);
            oldCommands.Add(keyW);
        }
        else if (Input.GetKeyDown(keycodePunch))
        {
            keyE.Execute(anim);
            oldCommands.Add(keyE);
        }
        else if (Input.GetKeyDown(keycodeMove))
        {
            upArrow.Execute(anim);
            oldCommands.Add(upArrow);
        }

        if (Input.GetKeyDown(keycodeReplay))
        {
            shouldStartReplay = true;
        }

        if(Input.GetKeyDown(keycodeReverse))
        {
            UndoLastCommand();
        }
    }

    void UndoLastCommand() {
        if (oldCommands.Count > 0)
        {
            Command c = oldCommands[oldCommands.Count - 1];
            c.Execute(anim, false); //Make it run backwards

            oldCommands.RemoveAt(oldCommands.Count - 1);
        }
    }

    void StartReplaying() {
        if(shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;
            if (replayCoroutine != null) {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands() {
        isReplaying = true;
        for (int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(anim);
            yield return new WaitForSeconds(1f);
        }
        isReplaying = false;
    }
}
