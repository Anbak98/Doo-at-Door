using UnityEngine;
using DD.System.Input;

namespace DD.Character.Player
{    
    public class PlayerCharacterController : MonoBehaviour
    {
        [Header("Components on Prefab")]
        [SerializeField] private Transform _root;
        [SerializeField] private PlayerCharacterStatHandler _status;
        [SerializeField] private PlayerCharacterRender      _render;

        private void FixedUpdate()
        {
            if (InputActionManager.Instance.GetCharacterInput(out var input))
            {
                if (input.MoveInput.magnitude > 0)
                {
                    _status.SetSpeed(EMoveType.Walk);   
                }
                else
                {
                    _status.SetSpeed(EMoveType.Idle);
                }

                if (input.MoveInput.x < 0)
                {
                    _render.IsFlip = true;
                }
                else if (input.MoveInput.x > 0)
                {
                    _render.IsFlip = false;
                }

                MoveCharacter(input.MoveInput);
            }
        }

        private void LateUpdate()
        {
            _render.Render();
        }

        private void MoveCharacter(Vector3 moveInput)
        {
            _root.position += _status.CurSpeed * Time.deltaTime * moveInput;
        }
    }
}