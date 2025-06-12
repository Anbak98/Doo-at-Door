using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterRender : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Image _fillImage;

    private MonsterStatHandler _status;

    public bool isFlip = false;
    public bool isHit = false;

    public static readonly int hitHash = Animator.StringToHash("Hit");
    public static readonly int deadHash = Animator.StringToHash("Dead");
    public static readonly int runHash = Animator.StringToHash("Run");

    public void Init(MonsterStatHandler status)
    {
        _status = status;
        Init();
    }

    public void Init()
    {
        isHit = true;
        _animator.Play(runHash);
    }

    public void Render()
    {
        _fillImage.fillAmount = (float)_status.CurHP / (float)_status.BaseHP;

        if (_status.IsDead)
        {
            _animator.Play(deadHash);
        }
        else
        {
            _spriteRenderer.flipX = isFlip;

            if (isHit)
            {
                _animator.Play(hitHash);
                isHit = false;
            }
        }
    }

    public void SetFill(float normalizedValue)
    {
        _fillImage.fillAmount = normalizedValue;
    }
}