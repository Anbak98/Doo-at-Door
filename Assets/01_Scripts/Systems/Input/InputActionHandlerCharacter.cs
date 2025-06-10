using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionHandlerCharacter
{
    /// <summary>
    /// �Ӽ�(Property)�� ����(ref)�� ������ �� �����Ƿ�, ref ���� �Ϸ��� �ʵ�� �ٲ��
    /// </summary>
    public Vector3 MoveInput { get; private set; } = Vector2.zero;      // �̵� ���� (Vector3)

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
