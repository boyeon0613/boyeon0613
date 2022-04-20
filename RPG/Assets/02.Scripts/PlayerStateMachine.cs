using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public State state;
    public PlayerState playerState;

    [HideInInspector] public PlayerStateMachineManager manager;
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public PlayerAnimator playerAnimator;

    public bool isFinish
    {
        get
        {
            return state == State.Finish ? true : false;
        }
    }

    public virtual void Awake()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        manager = GetComponent<PlayerStateMachineManager>();
        controller=GetComponent<CharacterController>();
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
