using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ItemInfo
{
    public int ItemID;

    public string Name;

    public string Description;

    public int UnlockLev;

    public int MaxHP;

    public float MaxHPMul;

    public int MaxMP;

    public float MaxMPMul;

    public int MaxAtk;

    public float MaxAtkMul;

    public int MaxDef;

    public float MaxDefMul;

    public int Status;

}

public class ItemInfoLoader : IDataLoader
{
    public List<ItemInfo> ItemsList { get; private set; }
    public Dictionary<int, ItemInfo> ItemsDict { get; private set; }

    public ItemInfoLoader(string path = "JSON/ItemInfo")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<int, ItemInfo>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.ItemID, item);
        }
    }

    [Serializable]
    private class Wrapper { public List<ItemInfo> Items; }

    public ItemInfo GetByKey(int key) => ItemsDict.TryGetValue(key, out var value) ? value : null;
    public ItemInfo GetByIndex(int index) => (index >= 0 && index < ItemsList.Count) ? ItemsList[index] : null;
}
