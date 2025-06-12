using DD.System.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

namespace DD.Character.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        private InputActionHandlerCharacter _input;

        private PlayerCharacterStatHandler _status;
        private PlayerCharacterController _controller;
        private PlayerCharacterCollector _collector;
        private PlayerCharacterSimpleInventory _inventory;

        [Header("Data")]
        [SerializeField] private PlayerCharacterData PlayerCharacterData;

        [Header("Behaviours")]
        [SerializeField] private PlayerCharacterRender _render;
        [SerializeField] private PlayerCharacterWeapon _weapon;

        private void Start()
        {
            PlayerCharacterData.Init();

            _status = new(PlayerCharacterData.Info);
            _controller = new(transform, _status);
            _collector = new(transform);
            _inventory = new();

            _render.Init(_status, PlayerCharacterData.Animator);

            if (InputActionManager.Instance.GetCharacterInput(out var input))
            {
                _input = input;
            }
        }

        private void Update()
        {
            if (_input.MoveInput.magnitude > 0)
            {
                _status.SetSpeed(EMoveType.Walk);
            }
            else
            {
                _status.SetSpeed(EMoveType.Idle);
            }

            if (_input.MoveInput.x < 0)
            {
                _render.IsFlip = true;
            }
            else if (_input.MoveInput.x > 0)
            {
                _render.IsFlip = false;
            }

            _weapon.DetectAndDamage();
            _collector.Collect();
        }


        private void FixedUpdate()
        {
            _controller.MoveCharacter(_input.MoveInput);
            _weapon.HandleWeaponPosition();
        }

        private void LateUpdate()
        {
            _render.Render();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out ICollectable collectable))
            {
                _inventory.Add(collectable.Get());
            }
        }

        public void ApplyDamage(int amount)
        {
        }
    }
}
