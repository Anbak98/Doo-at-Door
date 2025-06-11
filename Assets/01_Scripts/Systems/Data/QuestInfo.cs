using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class QuestInfo
{
    public string QuestID;

    public int Type;

    public int NPC;

    public string Name;

    public string Title;

    public string Description;

    public int PriorID;

    public int Goal;

    public int GoalID;

    public int Exp;

    public int Gold;

    public bool Clear;

    public int Reward;

}

public class QuestInfoLoader : IDataLoader
{
    public List<QuestInfo> ItemsList { get; private set; }
    public Dictionary<string, QuestInfo> ItemsDict { get; private set; }

    public QuestInfoLoader(string path = "JSON/QuestInfo")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<string, QuestInfo>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.QuestID, item);
        }
    }

    [Serializable]
    private class Wrapper { public List<QuestInfo> Items; }

    public QuestInfo GetByKey(string key) => ItemsDict.TryGetValue(key, out var value) ? value : null;
    public QuestInfo GetByIndex(int index) => (index >= 0 && index < ItemsList.Count) ? ItemsList[index] : null;
}
