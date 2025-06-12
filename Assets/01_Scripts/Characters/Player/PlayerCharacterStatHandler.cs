using UnityEngine;

namespace DD.Character.Player
{
    public enum EMoveType
    {
        Run,
        Walk,
        Idle
    }

    public class PlayerCharacterStatHandler
    {
        private readonly PlayerInfo _info;
        public int CurHP { get; private set; } = int.MinValue;
        public int CurMP { get; private set; } = int.MinValue;
        public int CurStamina { get; private set; } = int.MinValue;
        public float CurSpeed { get; private set; } = float.NaN;

        public PlayerCharacterStatHandler(PlayerInfo Playerinfo)
        {
            _info = Playerinfo;

            CurSpeed = 0f;
            CurHP = _info.MaxHP;
            CurMP = _info.MaxMP;
            CurStamina = _info.MaxStamina;
        }

        public void SetSpeed(EMoveType type)
        {
            if (type == EMoveType.Walk)
                CurSpeed = _info.WalkSpeed;
            else if (type == EMoveType.Run)
                CurSpeed = _info.RunSpeed;
            else
                CurSpeed = 0f;
        }

        public EMoveType GetMoveType()
        {
            if (CurSpeed == _info.WalkSpeed)
                return EMoveType.Walk;
            else if (CurSpeed == _info.RunSpeed)
                return EMoveType.Run;
            else
                return EMoveType.Idle;
        }
    }
}
