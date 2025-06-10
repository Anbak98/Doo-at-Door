using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionHandlerCharacter
{
    /// <summary>
    /// 속성(Property)은 참조(ref)로 전달할 수 없으므로, ref 전달 하려면 필드로 바꿔라
    /// </summary>
    public Vector3 MoveInput { get; private set; } = Vector2.zero;      // 이동 방향 (Vector3)

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
            MoveInput = new Vector3(moveInput.x, 0f, moveInput.y);
    }
}
