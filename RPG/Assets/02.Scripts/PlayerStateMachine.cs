using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public State state;
    public PlayerState playerState;
    public PlayerAnimator playerAnimator;
    public PlayerStateMachineManager playerStateMachineManager;
    public virtual void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerStateMachineManager = GetComponent<PlayerStateMachineManager>();
    }
    public virtual bool IsExecuteOK()
    {
        return true;
    }
    public virtual void Execute()
    {
        state = State.Prepare;
    }

    public virtual PlayerState Workflow()
    {
        PlayerState nextState = playerState;

        switch (state)
        {
            case State.Idle:
                break;
            case State.Prepare:
                break;
            case State.Casting:
                break;
            case State.OnAction:
                break;
            case State.Finish:
                break;
            default:
                break;
        }
        return nextState;
    }

    public virtual void ForceStop()
    {
        state = State.Idle;
    }

    public virtual void UpdateState()
    {
        
    }

    public virtual void OnReset()
    {

    }

    public enum State
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish
    }
}
