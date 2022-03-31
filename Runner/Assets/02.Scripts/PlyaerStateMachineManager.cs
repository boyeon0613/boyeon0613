using System;
using System.Collections.Generic;
using UnityEngine;

public class PlyaerStateMachineManager : MonoBehaviour
{
    PlayerStateMachine[] playerStateMachines;
    KeyCode keyInput;

    private void Awake()
    {
       playerStateMachines = GetComponents<PlayerStateMachine>();
    }

    private void Update()
    {
        foreach (var machine in playerStateMachines)
        {
            if(keyInput == machine.keyCode)
            {
                if (machine.IsExecuteOK()) 
                    machine.Execute();
                keyInput = KeyCode.None;
                break;
            }
            
        }
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if(e.isKey && e.keyCode != KeyCode.None)
        {
            keyInput = e.keyCode;
        }
    }
}

