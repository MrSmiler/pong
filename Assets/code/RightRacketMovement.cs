using Game.Core;

public class RightRacketMovement : RacketMovement
{
    public void OnMove(ref RightRacketMoveInputEvent data)
    {
        moveDirection = data.direction;
    }
    private void OnEnable()
    {
        GameEventManager.GetInputEventBus().SubscribeTo<RightRacketMoveInputEvent>(OnMove);
    }
    private void OnDisable()
    {
        GameEventManager.GetInputEventBus().UnsubscribeFrom<RightRacketMoveInputEvent>(OnMove);
    }

}