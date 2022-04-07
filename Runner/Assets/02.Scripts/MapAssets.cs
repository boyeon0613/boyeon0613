using System;
using System.Collections.Generic;
using UnityEngine;

public class MapAssets : MonoBehaviour
{
    private static MapAssets _instance;

    public static MapAssets instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<MapAssets>("MapAssets"));
                _instance.RegisterAllMapToObjectPool();
            }
            return _instance;
        }
    }

    public List<GameObject> maps = new List<GameObject>();

    public void RegisterAllMapToObjectPool()
    {
        foreach (GameObject tower in maps)
        {
            ObjectPool.instance.AddPoolElement(new PoolElement
            {
                prefab = tower,
                size = 20,
                tag = tower.name
            });

        }
    }

}

