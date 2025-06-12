using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMonsterStatus : MonoBehaviour
{
    public MonsterStatHandler statHandler;

    [ReadOnly] public int CurHP;
    [ReadOnly] public int CurAttack;
    [ReadOnly] public float CurMoveSpeed;
    [ReadOnly] public float CurAttackSpeed;
    [ReadOnly] public int CurAttackRange;
    [ReadOnly] public int CurEXP;

    private void Update()
    {
        if (statHandler != null)
        {
            CurHP = statHandler.CurHP;
            CurAttack = statHandler.CurAttack;
            CurMoveSpeed = statHandler.CurMoveSpeed;
            CurAttackSpeed = statHandler.CurAttackSpeed;
            CurAttackRange = statHandler.CurAttackRange;
            CurEXP = statHandler.CurEXP;
        }
    }
}
