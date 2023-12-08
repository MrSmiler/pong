using GenericEventBus;

namespace Game.Core
{

    public class GameEventManager
    {
        private static GameEventManager _instance;
        private GenericEventBus<IGameEvent> _gameEventBus;
        private GenericEventBus<IInputEvent> _inputEventBus;

        private static GameEventManager Instance()
        {
            if (_instance == null)
            {
                _instance = new GameEventManager();
                _instance._gameEventBus = new GenericEventBus<IGameEvent>();
                _instance._inputEventBus = new GenericEventBus<IInputEvent>();
            }
            return _instance;
        }

        public static GenericEventBus<IGameEvent> GetGameEventBus()
        {
            return Instance()._gameEventBus;
        }
        public static GenericEventBus<IInputEvent> GetInputEventBus()
        {
            return Instance()._inputEventBus;
        }
    }
}
