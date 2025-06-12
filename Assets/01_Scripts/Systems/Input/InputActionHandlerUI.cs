using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionHandlerUI
{

    public Action IsKeyboadP;

    public InputActionHandlerUI(PlayerInputAction.UIActions uiInputActions)
    {
        
        uiInputActions.P.performed += OnPressedP;
    }

    private void OnPressedP(InputAction.CallbackContext context)
    {
        IsKeyboadP?.Invoke();
    }
}
