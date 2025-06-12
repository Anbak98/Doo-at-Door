using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatHandler
{
    public readonly MonsterInfo info;

    public int BaseHP { get; private set; }
    public int CurHP { get; private set; }
    public int CurAttack { get; private set; }
    public float CurMoveSpeed { get; private set; }
    public float CurAttackSpeed { get; private set; }
    public int CurAttackRange { get; private set; }
    public int CurEXP { get; private set; }

    public bool IsDead { get; private set; }

    public MonsterStatHandler(MonsterInfo info)
    {
        this.info = info;
        Init();
    }

    public void Init()
    {
        BaseHP = (int)(info.MaxHP * info.MaxHPMul);
        CurHP = BaseHP;
        CurAttack = (int)(info.Attack * info.AttackMul);
        CurAttackRange = (int)(info.AttackRange * info.AttackRangeMul);
        CurMoveSpeed = info.MoveSpeed;
        CurAttackSpeed = info.AttackSpeed;
        CurEXP = Random.Range(info.MinExp, info.MaxExp);
        IsDead = false;
    }

    public bool ChangeHPAndCheckDead(int amount)
    {
        CurHP += amount;

        if (CurHP <= 0)
        {
            CurHP = 0;
            IsDead = true;
            return true;
        }

        return false;
    }
}
