using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDataLoader { }

public class DataManager
{
    private Dictionary<Type, IDataLoader> _loaderMap = new()
    {
      { typeof(ItemInfoLoader), new ItemInfoLoader() },
      { typeof(MonsterInfoLoader), new MonsterInfoLoader() },
      { typeof(PlayerInfoLoader), new PlayerInfoLoader() },
      { typeof(QuestInfoLoader), new QuestInfoLoader() },
    };

    public T GetLoader<T>() where T : IDataLoader
    {
      return (T)_loaderMap[typeof(T)];
    }
}
