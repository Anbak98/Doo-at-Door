using DD.Character.Monster;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ObjectPool : SingletonBehaviour<ObjectPool>
{
    private Dictionary<Type, List<GameObject>> pools = new();
    private readonly  int poolSize = 10;

    // Addressables 키 매핑
    private Dictionary<Type, string> addressKeys = new()
    {
        { typeof(EnemyZeroBehaviour), "Assets/02_Prefabs/Characters/Monster/Enemy0.prefab" },
        { typeof(EnemyOneBehaviour), "Assets/02_Prefabs/Characters/Monster/Enemy1.prefab" },
        { typeof(EnemyTwoBehaviour), "Assets/02_Prefabs/Characters/Monster/Enemy2.prefab" },
        { typeof(EnemyThrBehaviour), "Assets/02_Prefabs/Characters/Monster/Enemy3.prefab" },
        { typeof(EnemyFouBehaviour), "Assets/02_Prefabs/Characters/Monster/Enemy4.prefab" },
        { typeof(ItemInstance), "Assets/02_Prefabs/Items/Item.prefab" },
    };

    protected override void Awake()
    {
        base.Awake();
        InitAsync();
    }

    private async void InitAsync()
    {
        foreach (var kvp in addressKeys)
        {
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(kvp.Value);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                var prefab = handle.Result;

                // 리스트가 없으면 초기화
                if (!pools.ContainsKey(kvp.Key))
                    pools[kvp.Key] = new List<GameObject>();

                for (int i = 0; i < poolSize; ++i)
                {
                    var obj = Instantiate(prefab);
                    obj.SetActive(false);
                    pools[kvp.Key].Add(obj);
                }
            }
            else
            {
                Debug.LogError($"Failed to load prefab for type {kvp.Key} with key '{kvp.Value}'");
            }
        }
    }

    public GameObject Get<T>() where T : IPooledObject
    {
        var type = typeof(T);

        if (pools.TryGetValue(type, out var list))
        {
            foreach (var obj in list)
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                    obj.GetComponent<IPooledObject>()?.OnGetFromPool();
                    return obj;
                }
            }

            Debug.LogWarning($"[ObjectPool] No available pooled object of type {type}. Consider expanding the pool.");
        }
        else
        {
            Debug.LogWarning($"[ObjectPool] No pool found for type {type}");
        }

        return null;
    }

    public void Return<T>(GameObject obj) where T : IPooledObject
    {
        obj.SetActive(false);
        obj.GetComponent<IPooledObject>()?.OnReturnToPool();
    }
}
