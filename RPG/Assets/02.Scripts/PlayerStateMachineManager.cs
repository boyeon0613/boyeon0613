﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachineManager : MonoBehaviour
{
    public float turnSpeed = 1f;

    Vector3 direction;
    Vector3 move;
    Coroutine turnCoroutine = null;
    Animator animator;
    Rigidbody rb;
    Transform tr;
    private bool isMove;

    Vector3 targetAngle;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        targetAngle = tr.eulerAngles;
    }
    private void Update()
    {
        bool tmpMove = false;
        Vector3 tmpDir = tr.forward;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //1. 만약에 플레이어 Y축 각도 0아니면 0될 때까지 회전
            //2. 앞으로 전진
            tmpDir = Vector3.forward;
            targetAngle = Vector3.up;
            tmpMove = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //1. 만약에 플레이어 Y축 각도 180 아니면 180될 때까지 회전
            //2. 뒤로 전진
            tmpDir = -tr.forward;
            targetAngle = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //1. 만약에 플레이어 Y축 각도 180 아니면 180될 때까지 회전
            //2. 왼쪽으로 전진

            tmpDir = (tmpDir - tr.right).normalized;
            targetAngle = new Vector3(0, -90, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //1. 만약에 플레이어 Y축 각도 180 아니면 180될 때까지 회전
            //2. 오른쪽으로 전진
            tmpDir = (tmpDir + tr.right).normalized;
            targetAngle = new Vector3(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //점프하기
        }       
        isMove = tmpMove;
    }
    private void FixedUpdate()
    {
        if (isMove)
        {

            targetAngle *= turnSpeed * Time.fixedDeltaTime;
            targetAngle += tr.eulerAngles;
            tr.eulerAngles = new Vector3(tr.eulerAngles.x,
                                Mathf.Lerp(tr.eulerAngles.y, targetAngle.y, 0.5f),
                                tr.eulerAngles.z);
        }

    }

    private void Rotate(Vector3 delta)
    {

    }

  
    public enum PlayerState
    {
        Idle,
        Walk,
        Run,
        Jump,
        Fall
    }
}