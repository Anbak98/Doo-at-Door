using UnityEngine;

namespace DD.System.Input
{
    public enum EPlayerInput
    {
        move,
    }

    public struct SPlayerCharacterInput
    {
        public Vector3 moveInput;
        public bool IsInteract;
    }

    public class InputActionManager : SingletonBehaviour<InputActionManager>
    {
        private PlayerInputAction _playerInputAction;

        private InputActionHandlerCharacter _cInputHandler;
        private InputActionHandlerUI _uiInputHander;

        protected override void Awake()
        {
            base.Awake();

            _playerInputAction = new PlayerInputAction();
            _cInputHandler = new InputActionHandlerCharacter(_playerInputAction.Character);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _playerInputAction.Enable();
        }

        public bool GetCharacterInput(out SPlayerCharacterInput input)
        {
            var data = new SPlayerCharacterInput
            {
                moveInput = _cInputHandler.MoveInput,
            };

            input = data;

            return true;
        }
    }
}