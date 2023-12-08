using System;
using Game.Core;
using UnityEngine;

public class GoalTracker : MonoBehaviour
{
    [SerializeField]
    private bool _rightGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (_rightGoal)
            {
                GameEventManager.GetGameEventBus().Raise(new RightGoalTriggerdEvent { ballGameObject = collision.gameObject });
                Debug.Log("Right Goal trigger event Raised");
            }
            else
            {
                GameEventManager.GetGameEventBus().Raise(new LeftGoalTriggerdEvent { ballGameObject = collision.gameObject });
                Debug.Log("Right Goal trigger event Raised");
            }
        }
        else
        {
            throw new Exception("Goal tracker was triggerd with somthing other than ball");
        }
    }
}
