using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStateMachine : MonoBehaviour
{
    public State state;
    public KeyCode keyCode;
    public Animator animator;

    private void Awake()
    {
        animator= GetComponent<Animator>();
    }
    //머신 동작 끝났는지 체크
    public bool isFinished
    {
        get
        {
            return state == State.Finish;
        }
    }

    /// <summary>
    /// 머신 동작 가능 여부 체크
    /// </summary>
    /// <returns></returns>
    public virtual bool IsExecuteOK()
    {
        return true;
    }

    /// <summary>
    /// 머신 동작
    /// </summary>
    public virtual void Execute()
    {
        state = State.Prepare;
    }
    /// <summary>
    /// 머신 동작 업데이트
    /// </summary>
    public virtual void UpdateState()
    {

    }

    /// <summary>
    /// 머신 강제종료
    /// </summary>
    public virtual void Stop()
    {
        state = State.Idle;
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

