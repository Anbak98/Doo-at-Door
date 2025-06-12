using DD.Item.Weapon;
using UnityEngine;

namespace DD.Character.Player
{
    public class PlayerCharacterWeapon : MonoBehaviour
    {
        [SerializeField] private Transform _root;
        [SerializeField] private Transform _weaponPivot;

        private float _rotationSpeed = 90f; // 초당 90도 회전

        public void EquipWeapon(IWeapon weapon)
        {
        }

        public void HandleWeaponPosition()
        {
            // 회전 중심(_root) 주위를 회전
            _weaponPivot.RotateAround(
                _root.position,          // 회전 중심
                Vector3.forward,              // 회전 축 (Y축 기준으로 회전)
                _rotationSpeed * Time.deltaTime // 회전 속도
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
            Gizmos.DrawWireCube(_weaponPivot.position, new Vector2(1, 1)); // radius와 동일
        }
    }
}