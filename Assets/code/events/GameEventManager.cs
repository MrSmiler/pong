using System.Collections;
using UnityEngine;
using GenericEventBus;
using Unity.VisualScripting;
using System;

namespace Game.Core { 

    public class GameEventManager
    {
        private static GameEventManager instance;
        private GenericEventBus<IGameEvent> gameEventBus;
        private GenericEventBus<IInputEvent> inputEventBus;

        private static GameEventManager Instance()
        {
            if (instance == null)
            {
                instance = new GameEventManager();
                instance.gameEventBus = new GenericEventBus<IGameEvent>();
                instance.inputEventBus = new GenericEventBus<IInputEvent>();
            }
            return instance;
        }

        public static GenericEventBus<IGameEvent> GetGameEventBus()
        {
            return Instance().gameEventBus;
        }
        public static GenericEventBus<IInputEvent> GetInputEventBus()
        {
            return Instance().inputEventBus;
        }
    }
}