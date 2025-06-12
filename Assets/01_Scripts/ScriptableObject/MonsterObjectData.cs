using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SMonsterData
{
    public string MonsterID;
    public GameObject MonsterPrefab;
    public Sprite Sprite;
}

[CreateAssetMenu(fileName = "MonsterObjectData", menuName = "Characters/Monster Object Data")]

public class MonsterObjectData : ScriptableObject
{
    public List<SMonsterData> monsterPrefabs;
}
