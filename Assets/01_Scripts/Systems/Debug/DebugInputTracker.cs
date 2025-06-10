using UnityEngine;
using DD.System.Input;

public class DebugInputTracker : MonoBehaviour
{
    void OnGUI()
    {
        if(InputActionManager.Instance.GetCharacterInput(out var input))
        {
            GUILayout.Label(
                "Move: " + input.moveInput + "\n" +
                "Interact: " + input.IsInteract
                );
        }
    }
}
