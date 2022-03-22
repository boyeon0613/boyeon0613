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

    //�ʿ��� Ŭ����
    //1.TowerPreview : Ÿ���� ���õǾ��� �� ���콺 Ŭ�� �̺�Ʈ�� ������ ģ��
    //2.TowerAssets : ��� Ÿ�� ������ ������ ���� ģ��, ������Ʈ Ǯ�� ��� Ÿ�� ���
}
