using Game.Core;
using GenericEventBus;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, GameInput.IPlayerActions
{
    //public GameEvent playerMoveInputEvent;
    //public GameEvent cameraZoomInputEvent;

    private GameInput _gameInput;
    private GenericEventBus<IInputEvent> _inputEventBus;
    private GameManager _gameManager;

    private void Awake()
    {
        _inputEventBus = GameEventManager.GetInputEventBus();
        _gameManager = GameManager.instance;
    }

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Player.SetCallbacks(this);
            _gameInput.Player.Enable();
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

