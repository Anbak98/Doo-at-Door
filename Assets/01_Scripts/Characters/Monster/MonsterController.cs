using DD.Character.Player;
using UnityEngine;

namespace DD.Character.Monster
{
    public class MonsterController
    {
        private Transform _root;
        private MonsterStatHandler _status;
        private MonsterRender _render;
        private PlayerCharacter _target;

        public MonsterController(Transform root, MonsterStatHandler status, MonsterRender render)
        {
            _root = root;
            _status = status;
            _render = render;
            _target = GameManager.Instance.Player;
        }

        public void MoveToPlayer()
        {
            Vector3 dir = (_target.transform.position - _root.position).normalized;
            if(dir.x > 0) 
                _render.isFlip = false;
            else if (dir.x < 0)
                _render.isFlip = true;
            _root.position += dir * _status.CurMoveSpeed * Time.deltaTime;
        }

        public void Knockback(float force)
        {
            Vector3 knockbackDirection = (_root.position - _target.transform.position).normalized;
            _root.position += knockbackDirection * force;
        }
    }
}