using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 direction;
    Vector3 move;

    private void Update()
    {
        Vector3 tmpDir = Vector3.zero;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            //1. 만약에 플레이어 Y축 각도 0아니면 0될 때까지 회전
            //2. 앞으로 전진
            tmpDir = Vector3.forward;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            //1. 만약에 플레이어 Y축 각도 180 아니면 180될 때까지 회전
            //2. 뒤로 전진
            tmpDir = Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //1. 만약에 플레이어 Y축 각도 180 아니면 180될 때까지 회전
            //2. 왼쪽으로 전진
  
            tmpDir = (tmpDir + Vector3.left).normalized;
        
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //1. 만약에 플레이어 Y축 각도 180 아니면 180될 때까지 회전
            //2. 오른쪽으로 전진
            tmpDir = (tmpDir + Vector3.right).normalized;

        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //점프하기
        }
        direction = tmpDir;
    }
}
