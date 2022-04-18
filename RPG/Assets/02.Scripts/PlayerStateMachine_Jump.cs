using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine_Jump : PlayerStateMachine
{
    public float deltaMove = 0.5f;
    private CharacterController controller;
    private PlayerMove playerMove;

    private float detectGroundTimeLimit = 1f;
    private float detectGroundTimer;
    private float jumpUpTime;
    private float jumpUpTimer;

    public override void Awake()
    {
        base.Awake();
        controller = GetComponent<CharacterController>();
        playerMove = GetComponent<PlayerMove>();
    }

    public override bool IsExecuteOK()
    {
        bool isOK = false;
        if ((playerStateMachineManager.playerState == PlayerState.Idle ||
           playerStateMachineManager.playerState == PlayerState.Move) &&
           controller.isGrounded)
        {
            isOK = true;
        }
        return isOK;
    }

    public override PlayerState Workflow()
    {
        PlayerState nextState = playerState;

        switch (state)
        {
            case State.Idle:
                break;
            case State.Prepare:
                playerAnimator.SetTrigger("doJump");
                detectGroundTimer = detectGroundTimeLimit;
                jumpUpTimer = jumpUpTime;
                state++;
                break;
            case State.Casting:
                if (controller.isGrounded == false)
                    state++;
                else if (detectGroundTimer < 0)
                    state = State.Finish;
                else
                    detectGroundTimer -= Time.deltaTime;
                playerMove.SetMove(deltaMove);
                break;
                case State.OnAction:
                if (controller.velocity.y < 0)
                {
                    playerAnimator.SetTrigger("doFall");
                }
                if (controller.isGrounded)
                    state++;

                if (jumpUpTimer < 0)
                {
                    playerMove.SetMove(deltaMove);
                    jumpUpTime -= Time.deltaTime;
                }
                 break;
            case State.Finish:
                nextState = PlayerState.Idle;
                state = State.Idle;
                break;
            default:
                break;
        }

        return nextState;
    }
}
