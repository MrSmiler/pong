using System.Collections;
using UnityEngine;

namespace Game.Core { 
    public interface IGameEvent {}

    public struct RightGoalTriggerdEvent : IGameEvent 
    { 
        public GameObject ballGameObject;
    }
    public struct LeftGoalTriggerdEvent : IGameEvent
    {
        public GameObject ballGameObject;
    }
}
