using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTracker : MonoBehaviour
{
    [SerializeField]
    private bool rightGoal;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (rightGoal) 
            {
                GameEventManager.GetGameEventBus().Raise(new RightGoalTriggerdEvent {ballGameObject = collision.gameObject});
                Debug.Log("Right Goal trigger event Raised");
            }
            else
            {
                GameEventManager.GetGameEventBus().Raise(new LeftGoalTriggerdEvent {ballGameObject = collision.gameObject});
                Debug.Log("Right Goal trigger event Raised");
            }
        }
        else
        {
            throw new Exception("Goal tracker was triggerd with somthing other than ball");
        }
    }
}
