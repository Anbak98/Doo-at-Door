using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerCharacterData", menuName = "Characters/Player Character Data")]

public class PlayerCharacterData : ScriptableObject
{
    public PlayerInfo Info { get; private set; }
    public AnimatorOverrideController Animator { get; private set; }

    [SerializeField] AnimatorOverrideController[] animatorOverrideControllers;

    public void Init()
    {
        string CharacterID = PlayerPrefs.GetString("SelectedPlayerCharacterID");
        Info = Global.Instance.DataManager.GetLoader<PlayerInfoLoader>().GetByKey(CharacterID);
        Animator = animatorOverrideControllers[Info.Type];
    }
}
