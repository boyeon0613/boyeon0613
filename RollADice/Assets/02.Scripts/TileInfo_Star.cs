using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInfo_Star : TileInfo
{
    private int _starValue;
    public int starValue
    {
        set
        {
            _starValue = value;
            starValueText.text = _starValue.ToString();
        }
        get
        {
            return _starValue;
        }
    }
    [SerializeField] Text starValueText;
    public override void TileEvent()
    {
        base.TileEvent();
        starValue++;
    }
    private void Awake()
    {
        _starValue = 3;
    }
}
