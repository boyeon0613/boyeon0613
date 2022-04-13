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
            //1. ���࿡ �÷��̾� Y�� ���� 0�ƴϸ� 0�� ������ ȸ��
            //2. ������ ����
            tmpDir = Vector3.forward;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            //1. ���࿡ �÷��̾� Y�� ���� 180 �ƴϸ� 180�� ������ ȸ��
            //2. �ڷ� ����
            tmpDir = Vector3.back;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //1. ���࿡ �÷��̾� Y�� ���� 180 �ƴϸ� 180�� ������ ȸ��
            //2. �������� ����
  
            tmpDir = (tmpDir + Vector3.left).normalized;
        
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //1. ���࿡ �÷��̾� Y�� ���� 180 �ƴϸ� 180�� ������ ȸ��
            //2. ���������� ����
            tmpDir = (tmpDir + Vector3.right).normalized;

        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //�����ϱ�
        }
        direction = tmpDir;
    }
}
