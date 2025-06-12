using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectPlayerCharacter : UIBase
{
    public void OnPressedCharacter(string id)
    {
        PlayerPrefs.SetString("SelectedPlayerCharacterID", id);
        GameManager.Instance.StartGame();
        Global.Instance.UIManager.Hide<UISelectPlayerCharacter>();
    }
}
