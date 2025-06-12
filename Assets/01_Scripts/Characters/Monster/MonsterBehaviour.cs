using System.Collections;
using UnityEngine;

namespace DD.Character.Monster
{
    public class MonsterBehaviour : MonoBehaviour, IPooledObject, IDamageable
    {
        [SerializeField] private string MonsterID;

        public MonsterInfo MonsterInfo {get; private set;}

        private MonsterController _controller;
        private MonsterStatHandler _status;

        [SerializeField] private MonsterRender _render;

        protected virtual void Start()
        {
            MonsterInfo = Global.Instance.DataManager.GetLoader<MonsterInfoLoader>().GetByKey(MonsterID);

            _status = new(MonsterInfo);
            _render.Init(_status);
            _controller = new(transform, _status, _render);
        }

        protected virtual void FixedUpdate()
        {
            if(!_status.IsDead)
            {
                _controller.MoveToPlayer();
            }
        }

        protected virtual void LateUpdate()
        {
            _render.Render();   
        }

        public virtual void ApplyDamage(int amount)
        {
            if (_status.IsDead)
                return;

            _render.isHit = true;
            _controller.Knockback(1);

            if (_status.ChangeHPAndCheckDead(-amount))
            {
                HandleDeath();
            }
        }

        public virtual void HandleDeath()
        {
            foreach(var itemID in MonsterInfo.DropItem)
            {
                var obj = ObjectPool.Instance.Get<ItemInstance>();

                if (obj != null)
                {
                    obj.GetComponent<ItemInstance>().Init(itemID);

                    // 무작위 오프셋 생성 (반지름 1 범위 내에서 랜덤 위치)
                    Vector3 randomOffset = Random.insideUnitCircle * 1.5f; // 1.5는 퍼지는 범위
                    randomOffset.y = 0f; // 바닥에만 퍼지게 하고 싶다면 Y축 고정

                    obj.transform.position = transform.position + randomOffset;
                }
            }

            StartCoroutine(WaitCleaning());
        }

        public IEnumerator WaitCleaning()
        {
            yield return new WaitForSeconds(2);

            ObjectPool.Instance.Return<MonsterBehaviour>(gameObject);
        }    

        public virtual void OnGetFromPool()
        {
            _status?.Init();
            _render?.Init();
        }

        public virtual void OnReturnToPool()
        {
        }

#if UNITY_EDITOR
        public MonsterStatHandler GetStatus() => _status;
#endif
    }
}
