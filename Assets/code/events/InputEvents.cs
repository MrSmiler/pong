using System.Collections;
using UnityEngine;
using System;


namespace Game.Core { 
    public interface IInputEvent {}

    public struct RacketMoveInputEvent : IInputEvent
    {
        public float direction;
    }
}
