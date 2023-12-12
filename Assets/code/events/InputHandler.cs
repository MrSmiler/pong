using Game.Core;
using GenericEventBus;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, GameInput.ISinglePlayerActions, GameInput.ITwoPlayerKeyboardActions
{
    //public GameEvent playerMoveInputEvent;
    //public GameEvent cameraZoomInputEvent;
    private GameInput _gameInput;
    private GenericEventBus<IInputEvent> _inputEventBus;
    private GenericEventBus<IGameEvent> _gameEventBus;
    private GameManager _gameManager;

    private void Awake()
    {
        _inputEventBus = GameEventManager.GetInputEventBus();
        _gameEventBus = GameEventManager.GetGameEventBus();
        _gameManager = GameManager.instance;

        _gameEventBus.SubscribeTo<PlayModeChanged>(PlayModeChangedHandler);
    }

    private void PlayModeChangedHandler(ref PlayModeChanged eventData)
    {
        if (eventData.playMode == EPlayMode.Single)
        {
            _gameInput.TwoPlayerKeyboard.Disable();
            _gameInput.SinglePlayer.Enable();
            Debug.LogWarning("play mode changed to Single");
        }
        else if (eventData.playMode == EPlayMode.TwoSameKeyboard)
        {
            _gameInput.TwoPlayerKeyboard.Enable();
            _gameInput.SinglePlayer.Disable();
            Debug.LogWarning("play mode changed to TwoPlayer");
        }
        else
        {
            throw new Exception("Wrong PlayMode");
        }
    }

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.TwoPlayerKeyboard.SetCallbacks(this);
            _gameInput.SinglePlayer.SetCallbacks(this);

            //_gameInput.TwoPlayerKeyboard.Enable();
        }
    }

    public void OnRightRacketMove(InputAction.CallbackContext context)
    {
        float moveValue = context.ReadValue<float>();
        _inputEventBus.Raise(new RightRacketMoveInputEvent { direction = moveValue });

    }
    public void OnLeftRacketMove(InputAction.CallbackContext context)
    {
        float moveValue = context.ReadValue<float>();
        _inputEventBus.Raise(new LeftRacketMoveInputEvent { direction = moveValue });
    }
    public void OnPauseMenuOpenClose(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_gameManager.CurrentState is EGameState.GameUnPause or EGameState.GameStart or EGameState.GameTimer)
            {
                _gameManager.UpdateState(EGameState.GamePause);
            }
            else
            {
                _gameManager.UpdateState(EGameState.GameUnPause);
            }
        }
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

