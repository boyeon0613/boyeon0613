using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    bool isTowerHere
    {
        get 
        {
            return towerInfo != null; 
        }
    }
    public TowerInfo towerInfo;

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
        if (TowerViewPresenter.instance.isSelected)
        {
            Transform previewTransform = TowerViewPresenter.instance.GetTowerPreviewTransform();
            previewTransform.gameObject.SetActive(true);
            previewTransform.position = transform.position + new Vector3(0, col.size.y / 2, 0);

            if (isTowerHere)
                rend.material.color = buildNotAvailableColor;
            else
                rend.material.color = buildAvailableColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = originColor;
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
            
        {
            if(isTowerHere &&
                TowerViewPresenter.instance.isSelected == false)
            {
                Debug.Log("Set ui here");
                TowerUI.instance.upgradePriceText.text = towerInfo.price.ToString();
                TowerUI.instance.sellPriceText.text = (towerInfo.price * 0.8).ToString();
                TowerUI.instance.transform.position = transform.position+Vector3.up*2;
                TowerUI.instance.node = this;
                TowerUI.instance.gameObject.SetActive(true);
            }
            else if(isTowerHere == false &&
                TowerViewPresenter.instance.isSelected)
            {
                Transform previewTrasnform = TowerViewPresenter.instance.GetTowerPreviewTransform();
                string towerName = previewTrasnform.GetComponent<TowerPreview>().towerName;

                ObjectPool.SpawnFromPool(towerName,
                                         previewTrasnform.position);

                if(TowerAssets.instance.TryGetTowerInfoByName(towerName, out TowerInfo tmptowerInfo))
                {
                    //todo => spend mone : towerInfo.price
                    towerInfo = tmptowerInfo;
                }
                else
                {
                    Debug.Log($"Failed to get tower info of {towerName}");
                }
                previewTrasnform.gameObject.SetActive(false);
                TowerViewPresenter.instance.SetTowerHandler(null);
            }
            //build
        }
        else
        {
            TowerViewPresenter.instance.SetTowerHandler(null);
        }
    }

    //필요한 클래스
    //1.TowerPreview : 타워가 선택되었을 때 마우스 클릭 이벤트를 수행할 친구
    //2.TowerAssets : 모든 타워 정보를 가지고 있을 친구, 오브젝트 풀에 모든 타워 등록
}
