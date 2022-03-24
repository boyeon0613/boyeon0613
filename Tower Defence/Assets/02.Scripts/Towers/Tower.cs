using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tower : MonoBehaviour
{
    public TowerInfo info;
    public LayerMask enemyLayer;
    public float detectRange;

    public Transform turretRotationPoint;
    Transform tr;
    private void Awake()
    {
        tr = transform;
    }

    private void OnDisable()
    {
        ObjectPool.ReturnToPool(gameObject);
    }

    private void Update()
    {
        Collider[] cols = Physics.OverlapSphere(tr.position, detectRange, enemyLayer);
        
        if(cols.Length>0)
        {
            cols.OrderBy(x => (x.transform.position - WayPoints.points.Last().transform.position));
            turretRotationPoint.LookAt(cols[0]. transform);
        }
    }

}
