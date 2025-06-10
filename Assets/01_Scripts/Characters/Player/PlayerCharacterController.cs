using UnityEngine;
using DD.System.Input;

namespace DD.Character.Player
{    
    public class PlayerCharacterController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private PlayerCharacterStatHandler _status;

        private float _acceleration = 1f;

        private void Update()
        {
            if (InputActionManager.Instance.GetCharacterInput(out SPlayerCharacterInput input))
            {
                MoveCharacter(input.moveInput);
            }
        }

        public void SetStatus(float acceleration = float.MinValue)
        {
            if (acceleration != float.MinValue)
            {
                _acceleration = acceleration;
            }
        }

        private void MoveCharacter(Vector3 moveInput)
        {
            _characterTransform.position += _acceleration * Time.deltaTime * moveInput;
        }
    }
}