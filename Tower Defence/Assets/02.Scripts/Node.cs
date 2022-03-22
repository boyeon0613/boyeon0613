using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color originColor;
    public Color buildAvailableColor;
    public Color buildNotAvailableColor;

    Renderer rend;
    BoxCollider col;
    
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<BoxCollider>();
        originColor = rend.material.color;
    }
    private void OnMouseEnter()
    {
        rend.material.color = buildAvailableColor;
        if (TowerViewPresenter.instance.isSelected)
        {
            Transform previewTransform = TowerViewPresenter.instance.GetTowerPreviewTransform();
            previewTransform.gameObject.SetActive(true);
            previewTransform.position = transform.position + new Vector3(0, col.size.y / 2, 0);
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = originColor;
    }
    private void OnMouseDown()
    {
        if(TowerViewPresenter.instance.isSelected)
        {
            Transform previewTrasnform = TowerViewPresenter.instance.GetTowerPreviewTransform();
            ObjectPool.SpawnFromPool(previewTrasnform.GetComponent<TowerPreview>().towerName,
                                     previewTrasnform.position);
        }
        //build
    }

    //필요한 클래스
    //1.TowerPreview : 타워가 선택되었을 때 마우스 클릭 이벤트를 수행할 친구
    //2.TowerAssets : 모든 타워 정보를 가지고 있을 친구, 오브젝트 풀에 모든 타워 등록
}
