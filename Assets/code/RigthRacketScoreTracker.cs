using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;
using UnityEngine.UI;

public class RigthRacketScoreTracker : MonoBehaviour
{
    // Start is called before the first frame update
    private Text textLabel;

    private void Start()
    {
        textLabel = GetComponent<Text>();        
    }

    private void OnEnable()
    {
        GameEventManager.GetGameEventBus().SubscribeTo<LeftGoalTriggerdEvent>(RigthRacketScored); 
    }

    private void OnDisable()
    {
        GameEventManager.GetGameEventBus().SubscribeTo<LeftGoalTriggerdEvent>(RigthRacketScored); 
    }

    void RigthRacketScored(ref LeftGoalTriggerdEvent eventData)
    {
        int currentScore = int.Parse(textLabel.text);
        currentScore++;
        textLabel.text = currentScore.ToString();
    }
}