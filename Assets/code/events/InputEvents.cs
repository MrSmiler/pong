namespace Game.Core
{
    public interface IInputEvent { }

    public struct RightRacketMoveInputEvent : IInputEvent
    {
        public float direction;
    }
    public struct LeftRacketMoveInputEvent : IInputEvent
    {
        public float direction;
    }
}
