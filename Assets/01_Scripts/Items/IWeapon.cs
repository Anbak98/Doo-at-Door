using DD.Character;
using UnityEngine;

namespace DD.Item.Weapon
{
    public interface IWeapon
    {
        void DetectAndAttack();
        void SetPosition(Transform player, Transform hand);
        void Attack(IDamageable damageable);
    }
}