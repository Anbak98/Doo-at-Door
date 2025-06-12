using UnityEngine;

namespace DD.Character.Player
{
    public class PlayerCharacterCollector
    {
        private Transform _root;
        private float _radius = 5f;

        public PlayerCharacterCollector(Transform root)
        {
            _root = root;
        }

        public void Collect()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(_root.position, _radius);

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out ICollectable collectable))
                {
                    collectable.Drain(_root);
                }
            }
        }
    }
}