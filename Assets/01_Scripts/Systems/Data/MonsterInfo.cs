using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class MonsterInfo
{
    public string MonsterID;

    public string Name;

    public string Description;

    public int Attack;

    public float AttackMul;

    public int MaxHP;

    public float MaxHPMul;

    public int AttackRange;

    public float AttackRangeMul;

    public float AttackSpeed;

    public float MoveSpeed;

    public int MinExp;

    public int MaxExp;

    public int[] DropItem;

}

public class MonsterInfoLoader : IDataLoader
{
    public List<MonsterInfo> ItemsList { get; private set; }
    public Dictionary<string, MonsterInfo> ItemsDict { get; private set; }

    public MonsterInfoLoader(string path = "JSON/MonsterInfo")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<string, MonsterInfo>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.MonsterID, item);
        }
    }

    [Serializable]
    private class Wrapper { public List<MonsterInfo> Items; }

    public MonsterInfo GetByKey(string key) => ItemsDict.TryGetValue(key, out var value) ? value : null;
    public MonsterInfo GetByIndex(int index) => (index >= 0 && index < ItemsList.Count) ? ItemsList[index] : null;
}
