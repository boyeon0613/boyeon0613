using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo_Inverse : TileInfo
{
    public override void TileEvent()
    {
        Debug.Log("TileEvent : Switch Dice Panel");
        DicePlayUI.instance.SwitchDicePanel();
    }

}
