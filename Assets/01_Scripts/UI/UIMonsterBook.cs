using DD.Character.Monster;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMonsterBook : UIBase
{
    [SerializeField] private TMPro.TMP_Text _text;
    [SerializeField] private Image image;
    [SerializeField] private MonsterObjectData _monsterData;
    [SerializeField] private GameObject _list;
    [SerializeField] private GameObject _slot;

    public void Start()
    {
        foreach(var obj in _monsterData.monsterPrefabs)
        {
            var slot = Instantiate(_slot);
            slot.GetComponent<SlotUI>().Init(this, obj);
            slot.transform.parent = _list.transform;
        }
    }

    public void ShowInfo(SMonsterData monsterData)
    {
        image.sprite = monsterData.Sprite;
        MonsterInfo info = Global.Instance.DataManager.GetLoader<MonsterInfoLoader>().GetByKey(monsterData.MonsterID);
        _text.text =
            "MonsterID: " + info.MonsterID + "\n" +
            "Name: " + info.Name + "\n" +
            "Description: " + info.Description + "\n" +
            "HP: " + info.MaxHP + "\n" +
            "Attack: " + info.Attack + "\n" +
            "Speed: " + info.MoveSpeed + "\n";
    }
}
