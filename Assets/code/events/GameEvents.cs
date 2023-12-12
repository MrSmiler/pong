using UnityEngine;

namespace Game.Core
{
    public interface IGameEvent { }

    public struct RightGoalTriggerdEvent : IGameEvent
    {
        public GameObject ballGameObject;
    }
    public struct LeftGoalTriggerdEvent : IGameEvent
    {
        public GameObject ballGameObject;
    }
    public struct PongStarted : IGameEvent
    {
    }
    public struct PongEnded : IGameEvent
    {
    }
    public struct PlayModeChanged : IGameEvent
    {
        public EPlayMode playMode;
    }
}
