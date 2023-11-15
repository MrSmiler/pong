using System.Collections;
using UnityEngine;

namespace Game.Core { 
    public interface IGameEvent {}

    public struct RightGoalTriggerdEvent : IGameEvent {}
    public struct LeftGoalTriggerdEvent : IGameEvent {}
}
