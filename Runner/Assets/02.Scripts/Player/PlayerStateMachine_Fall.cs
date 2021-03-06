using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine_Fall : PlayerStateMachine   
{
    private GroundDetector groundDetector;
    private Rigidbody rb;

    public override void Awake()
    {
        base.Awake();
        groundDetector = GetComponent<GroundDetector>();
        rb = GetComponent<Rigidbody>();
    }
    public override bool IsExecuteOK()
    {
        bool isOK = false;
        if (manager.state == PlayerState.Idle ||
           manager.state == PlayerState.Run ||
           manager.state == PlayerState.Jump)
            isOK = true;
        return isOK;
    }

    public override PlayerState UpdateState()
    {
        PlayerState nextPlayerState = playerState;
        switch (state)
        {
            case State.Idle:
                break;
            case State.Prepare:
                animator.Play("Fall");
                state++;
                break;
            case State.Casting:
                state++;
                break;
            case State.OnAction:
                if (groundDetector.isDetected)
                    state++;
                    break;
            case State.Finish:
                nextPlayerState = PlayerState.Idle;
                break;
            default:
                break;
        }
        return nextPlayerState;
    }
}
