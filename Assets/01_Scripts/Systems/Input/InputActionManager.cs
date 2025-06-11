using UnityEngine;

namespace DD.System.Input
{
    public enum EInputType
    {
        Character,
        UI
    }

    public class InputActionManager : SingletonBehaviour<InputActionManager>
    {
        private PlayerInputAction _playerInputAction;

        private InputActionHandlerCharacter _ccInputHandler;
        private InputActionHandlerUI        _uiInputHandler;

        protected override void Awake()
        {
            base.Awake();

            _playerInputAction = new();

            _ccInputHandler = new(_playerInputAction.Character);
            _uiInputHandler = new(_playerInputAction.UI);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _playerInputAction.Enable();
        }

        public bool GetCharacterInput(out InputActionHandlerCharacter input)
        {
            input = _ccInputHandler;

            return true;
        }
    }
}