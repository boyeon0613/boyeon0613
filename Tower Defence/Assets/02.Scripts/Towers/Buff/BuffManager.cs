using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static IEnumerator ActiveBuff(Enemy target, Buff buff)
    {
        buff.OnActive(target);

        bool doBuff = true;
        float timeMark = Time.time; //38�ʿ� �������� ���
        //while(Time.time(��� ��� ����) - timeMark(<=38��) < buff.duration(<=10��))
        while (doBuff&&
               Time.time - timeMark < buff.duration &&
               target != null) //���ӽð� - �����ߵ��ð� < �������ӽð�
        {
            doBuff = buff.OnDuration(target);
            yield return null; //�ش� �ݺ����� �����Ӵ� �� �� ����ǰ� �ϱ� ����.
        }
        buff.OnDeactive(target);
    }
}
