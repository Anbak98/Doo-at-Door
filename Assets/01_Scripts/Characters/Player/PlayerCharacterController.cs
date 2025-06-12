using UnityEngine;
using DD.System.Input;

namespace DD.Character.Player
{    
    public class PlayerCharacterController
    {
        private Transform _root;
        private PlayerCharacterStatHandler _status;

        public PlayerCharacterController(Transform root, PlayerCharacterStatHandler status)
        {
            _root = root;
            _status = status;
        }

        public void MoveCharacter(Vector3 moveInput)
        {
            _root.position += _status.CurSpeed * Time.deltaTime * moveInput;
        }
    }
}