using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public string PlayerCharacterID;

    public int Type;

    public string Description;

    public int MaxHP;

    public int MaxMP;

    public int MaxStamina;

    public float WalkSpeed;

    public float RunSpeed;

    public int Strength;

    public int Intelligence;

    public int Charisma;

    public int Luck;

    public int Defense;

}

public class PlayerInfoLoader : IDataLoader
{
    public List<PlayerInfo> ItemsList { get; private set; }
    public Dictionary<string, PlayerInfo> ItemsDict { get; private set; }

    public PlayerInfoLoader(string path = "JSON/PlayerInfo")
    {
        string jsonData;
        jsonData = Resources.Load<TextAsset>(path).text;
        ItemsList = JsonUtility.FromJson<Wrapper>(jsonData).Items;
        ItemsDict = new Dictionary<string, PlayerInfo>();
        foreach (var item in ItemsList)
        {
            ItemsDict.Add(item.PlayerCharacterID, item);
        }
    }

    [Serializable]
    private class Wrapper { public List<PlayerInfo> Items; }

    public PlayerInfo GetByKey(string key) => ItemsDict.TryGetValue(key, out var value) ? value : null;
    public PlayerInfo GetByIndex(int index) => (index >= 0 && index < ItemsList.Count) ? ItemsList[index] : null;
}
