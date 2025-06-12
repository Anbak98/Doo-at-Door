using DD.Character.Monster;
using UnityEngine;

public class MonsterSpawner
{
    public void SpawnRandomly()
    {
        int rand = Random.Range(0, 5);

        switch(rand)
        {
            case 0:
                ObjectPool.Instance.Get<EnemyZeroBehaviour>(); break;
            case 1:
                ObjectPool.Instance.Get<EnemyOneBehaviour>(); break;
            case 2:
                ObjectPool.Instance.Get<EnemyTwoBehaviour>(); break;
            case 3:
                ObjectPool.Instance.Get<EnemyThrBehaviour>(); break;
            case 4:
                ObjectPool.Instance.Get<EnemyFouBehaviour>(); break;
        }
        
    }
}
