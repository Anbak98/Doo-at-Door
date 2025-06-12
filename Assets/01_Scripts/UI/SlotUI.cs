using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    private UIMonsterBook _book;
    private SMonsterData _monsterInfo;

    public void Init(UIMonsterBook book, SMonsterData monsterInfo)
    {
        _book = book;
        _monsterInfo = monsterInfo;
        _image.sprite = monsterInfo.Sprite;
    }

    public void OnPressedSlot()
    {
        _book.ShowInfo(_monsterInfo);
    }
}
