using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : SingletonBehaviour<Global>
{
    public DataManager DataManager;

    protected override void Awake()
    {
        base.Awake();

        DataManager = new();
    }
}
