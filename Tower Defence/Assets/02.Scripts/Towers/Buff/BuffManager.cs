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
        float timeMark = Time.time; //38초에 실행했을 경우
        //while(Time.time(얘는 계속 증가) - timeMark(<=38초) < buff.duration(<=10초))
        while (doBuff&&
               Time.time - timeMark < buff.duration &&
               target != null) //게임시간 - 버프발동시간 < 버프지속시간
        {
            doBuff = buff.OnDuration(target);
            yield return null; //해당 반복문이 프레임당 한 번 실행되게 하기 위함.
        }
        buff.OnDeactive(target);
    }
}
