using System.Collections;
using UnityEngine;
using Game.Core;

public class LeftRacketMovement: RacketMovement
{
    public void OnMove(ref LeftRacketMoveInputEvent data)
    {
        moveDirection = data.direction;
    }

    private void OnEnable()
    {
        GameEventManager.GetInputEventBus().SubscribeTo<LeftRacketMoveInputEvent>(OnMove); 
    }
    private void OnDisable()
    {
        GameEventManager.GetInputEventBus().UnsubscribeFrom<LeftRacketMoveInputEvent>(OnMove); 
    }

}