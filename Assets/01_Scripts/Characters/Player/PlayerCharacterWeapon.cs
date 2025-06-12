using DD.Item.Weapon;
using UnityEngine;

namespace DD.Character.Player
{
    public class PlayerCharacterWeapon : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private Transform _weaponPivot;

        private float _rotationSpeed = 90f; // �ʴ� 90�� ȸ��

        public void EquipWeapon(IWeapon weapon)
        {
        }

        public void HandleWeaponPosition()
        {
            // ȸ�� �߽�(_root) ������ ȸ��
            _weaponPivot.RotateAround(
                _root.position,          // ȸ�� �߽�
                Vector3.forward,              // ȸ�� �� (Y�� �������� ȸ��)
                _rotationSpeed * Time.deltaTime // ȸ�� �ӵ�
            );
        }

        public void DetectAndDamage()
        {
            Collider2D[] hits = Physics2D.OverlapBoxAll(_weaponPivot.position, new Vector2(1,1), 1f);

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(3);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_weaponPivot.position, new Vector2(1, 1)); // radius�� ����
        }
    }
}