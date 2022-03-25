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
    public Transform target;
    Transform tr;

    private void Awake()
    {
        tr = transform;
    }

    private void OnDisable()
    {
        ObjectPool.ReturnToPool(gameObject);
    }

    public virtual void Update()
    {
        Collider[] cols = Physics.OverlapSphere(tr.position, detectRange, enemyLayer);
        
        if(cols.Length>0)
        {
            cols.OrderBy(x => (x.transform.position - WayPoints.points.Last().transform.position));
            target = cols[0].transform;
            turretRotationPoint.LookAt(cols[0]. transform);
        }
        else
        {
            target = null;
        }
    }

}
