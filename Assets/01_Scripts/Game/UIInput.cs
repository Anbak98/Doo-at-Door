using DD.System.Input;
using UnityEngine;

public class UIInput
{
    // Update is called once per frame
    public UIInput()
    {
        if (InputActionManager.Instance.GetUIInput(out var input))
        {
            input.IsKeyboadP += SwitchMonsterBook;
        }
    }

    private void SwitchMonsterBook()
    {
        if(Global.Instance.UIManager.Get<UIMonsterBook>() == null || Global.Instance.UIManager.Get<UIMonsterBook>().gameObject.activeSelf == false)
        {
            Global.Instance.UIManager.Show<UIMonsterBook>();
        }
        else
        {
            Global.Instance.UIManager.Hide<UIMonsterBook>();
        }
    }
}
