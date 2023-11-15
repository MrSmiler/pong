using Game.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.GetGameEventBus().SubscribeTo<RightGoalTriggerdEvent>(RightGoalTriggerd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RightGoalTriggerd(ref RightGoalTriggerdEvent eventData)
    {
        Debug.Log("Left Rackt scored");
    }
}
