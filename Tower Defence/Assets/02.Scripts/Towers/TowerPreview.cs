using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerPreview : MonoBehaviour
{
    public string towerName;

    private void OnMouseDown()
    {
        if (TowerViewPresenter.instance.isSelected)
        {
            ObjectPool.SpawnFromPool(towerName, transform.position);
        }
    }
}
