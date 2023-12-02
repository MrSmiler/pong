using Game.Core;
using GenericEventBus;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, GameInput.IPlayerActions
{
    //public GameEvent playerMoveInputEvent;
    //public GameEvent cameraZoomInputEvent;


    private GameInput gameInput;
    private GenericEventBus<IInputEvent> inputEventBus;
    private GameManager gameManager;

    void Awake()
    {
        inputEventBus = GameEventManager.GetInputEventBus();
        gameManager = GameManager.instance;
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
        inputEventBus.Raise(new RightRacketMoveInputEvent { direction = moveValue });

    }
    public void OnLeftRacketMove(InputAction.CallbackContext context)
    {
        float moveValue = context.ReadValue<float>();
        inputEventBus.Raise(new LeftRacketMoveInputEvent { direction = moveValue });
    }
    public void OnPauseMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            gameManager.updateState(GameState.GamePause);
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

