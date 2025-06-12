using DD.Character.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameManager : SingletonBehaviour<GameManager>
{
    public PlayerCharacter Player {get; private set;}

    private MonsterSpawner _monsterSpawner;
    private UIInput _uiInput;


    protected override void Awake()
    {
        base.Awake();
        _monsterSpawner = new();
        _uiInput = new();
    }

    protected override void Start()
    {
        base.Start();

        Global.Instance.UIManager.Show<UISelectPlayerCharacter>();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void SpawnMonster()
    {
        _monsterSpawner.SpawnRandomly();
    }

    public async void StartGame()
    {
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>("Assets/02_Prefabs/Characters/Player/Player.prefab");
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            var prefab = handle.Result;


            var obj = Instantiate(prefab);

            Player = obj.GetComponent<PlayerCharacter>();

            InvokeRepeating(nameof(SpawnMonster), 1F, 1F);
        }
        else
        {
            Debug.LogError($"Failed to load prefab Player");
        }
    }
}
