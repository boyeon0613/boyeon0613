using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;
    public float playTime;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        playTime += Time.deltaTime;
    }
}
