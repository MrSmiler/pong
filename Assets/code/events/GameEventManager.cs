using System.Collections;
using UnityEngine;
using GenericEventBus;
using Unity.VisualScripting;
using System;

namespace Game.Core { 

    public class GameEventManager
    {
        private static GameEventManager instance;
        private GenericEventBus<IGameEvent, GameObject> gameEventBus;
        private GenericEventBus<IInputEvent> inputEventBus;

        private static GameEventManager Instance()
        {
            if (instance == null)
            {
                instance = new GameEventManager();
                instance.gameEventBus = new GenericEventBus<IGameEvent, GameObject>();
                instance.inputEventBus = new GenericEventBus<IInputEvent>();
            }
            return instance;
        }

        public static GenericEventBus<IGameEvent, GameObject> GetGameEventBus()
        {
            return Instance().gameEventBus;
        }
        public static GenericEventBus<IInputEvent> GetInputEventBus()
        {
            return Instance().inputEventBus;
        }
    }
}