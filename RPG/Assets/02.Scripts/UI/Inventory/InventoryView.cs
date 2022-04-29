using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public static InventoryView instance;

    [SerializeField] private InventoryItemsView itemView_Equip;
    [SerializeField] private InventoryItemsView itemView_Spend;
    [SerializeField] private InventoryItemsView itemView_ETC;

    private void Awake()
    {
        instance = this;
    }

    public InventoryItemsView GetItemsView(ItemType itemType)
    {
        InventoryItemsView tmpView = null;

        switch (itemType)
        {
            case ItemType.None:
                break;
            case ItemType.Equip:
                tmpView = itemView_Equip;
                break;
            case ItemType.Spend:
                tmpView = itemView_Spend;
                break;
            case ItemType.ETC:
                tmpView = itemView_ETC;
                break;
            default:
                break;
        }
        return tmpView;
    }
}
