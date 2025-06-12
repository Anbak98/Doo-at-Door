using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SItem
{
    public int ItemID;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "ItemData", menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] private List<SItem> equipment;
    [SerializeField] private List<SItem> consume;
    [SerializeField] private List<SItem> material;

    public SItem GetItemData(int ItemID)
    {
        int type = ItemID / 10000;
        switch(type)
        {
            case 1:
                return equipment[ItemID % 1000];
            case 2:
                return consume[ItemID % 1000];
            case 3:
                return material[ItemID % 1000];
        }

        return default;
    }
}
