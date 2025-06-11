using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionHandlerCharacter
{
    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public bool IsInteract { get; private set; } = false;

    // Start is called before the first frame update
    public InputActionHandlerCharacter(PlayerInputAction.CharacterActions characterInputActions)
    {
        characterInputActions.Move.performed += SetMoveInput;
        characterInputActions.Move.canceled += SetMoveInput;
    }

    private void SetMoveInput(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        if (moveInput.sqrMagnitude < 0.01f)
            MoveInput = Vector2.zero;
        else
            MoveInput = new Vector2(moveInput.x, moveInput.y);
    }
}
