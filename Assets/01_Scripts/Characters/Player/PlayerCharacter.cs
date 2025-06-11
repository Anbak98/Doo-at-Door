using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Character.Player
{
    public class PlayerCharacter : MonoBehaviour
    {
        public PlayerInfo PlayerInfo { get; private set; }

        [Header("Components")]
        [SerializeField] private PlayerCharacterStatHandler _status;
        [SerializeField] private PlayerCharacterController _controller;
        [SerializeField] private PlayerCharacterRender _render;

        void Start()
        {
            PlayerInfo = Global.Instance.DataManager.GetLoader<PlayerInfoLoader>().GetByKey("PC0003");

            _status.Init(PlayerInfo);
            _render.Init(PlayerInfo.Type);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
