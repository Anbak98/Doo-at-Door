using DD.Character.Player;
using UnityEngine;

namespace DD.Character.Player
{
    public class PlayerCharacterRender : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterStatHandler _status;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator _anmator;
        [SerializeField] private AnimatorOverrideController[] characterOverrides; // 0 ~ 5번 캐릭터용

        public bool IsFlip = false;

        public void Init(int characyerIndex)
        {
            _anmator.runtimeAnimatorController = characterOverrides[characyerIndex];
        }

        public void Render()
        {
            spriteRenderer.flipX = IsFlip;

            switch (_status.GetMoveType())
            {
                case EMoveType.Run:
                    break;
                case EMoveType.Walk:
                    _anmator.SetBool("IsRun", true); break;
                case EMoveType.Idle:
                    _anmator.SetBool("IsRun", false); break;
            }
        }
    }
}
