using DD.Character.Player;
using UnityEngine;

namespace DD.Character.Player
{
    public class PlayerCharacterRender : MonoBehaviour
    {
        private PlayerCharacterStatHandler _status;

        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator _anmator;

        public bool IsFlip = false;

        public void Init(PlayerCharacterStatHandler status, AnimatorOverrideController animatorOverride)
        {
            _status = status;
            _anmator.runtimeAnimatorController = animatorOverride;
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
