using System;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEditor.Build.Content;
using GenericEventBus;
using Game.Core;

public class InputReader : MonoBehaviour, GameInput.IPlayerActions
{
    //public GameEvent playerMoveInputEvent;
    //public GameEvent cameraZoomInputEvent;


    private GameInput gameInput;
    private GenericEventBus<IInputEvent> inputEventBus;

    void Awake()
    {
        inputEventBus = GameEventManager.GetInputEventBus(); 
    }

	private void OnEnable()
	{
		if (gameInput == null)
		{
			gameInput = new GameInput();
            gameInput.Player.SetCallbacks(this);
            gameInput.Player.Enable();
		}

	}
    
    public void OnRightRacketMove(InputAction.CallbackContext context)
    {
        float moveValue = context.ReadValue<float>();
        inputEventBus.Raise(new RacketMoveInputEvent { direction = moveValue});

    }
    public void OnLeftRacketMove(InputAction.CallbackContext context)
    {
        float moveValue = context.ReadValue<float>();
        Debug.Log(moveValue);
    }

    //public void OnMove(InputAction.CallbackContext context)
    //{
    //    Vector2 direction = context.ReadValue<Vector2>();
    //    inputEventBus.Raise(new MoveInputEvent { direction = direction });
    //}

    //public void OnZoom(InputAction.CallbackContext context)
    //{
    //    Single zoomValue = context.ReadValue<Single>();
    //    inputEventBus.Raise(new ZoomInputEvent { value = zoomValue });
    //}
}

