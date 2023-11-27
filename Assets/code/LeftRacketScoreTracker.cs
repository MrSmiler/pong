using Game.Core;
using UnityEngine;
using UnityEngine.UI;

public class LeftRacketScoreTracker : MonoBehaviour
{
    private Text textLabel;

    private void Start()
    {
        textLabel = GetComponent<Text>();
    }

    private void OnEnable()
    {
        GameEventManager.GetGameEventBus().SubscribeTo<RightGoalTriggerdEvent>(LeftRacketScored);
    }

    private void OnDisable()
    {
        GameEventManager.GetGameEventBus().SubscribeTo<RightGoalTriggerdEvent>(LeftRacketScored);
    }

    void LeftRacketScored(ref RightGoalTriggerdEvent eventData)
    {
        int currentScore = int.Parse(textLabel.text);
        currentScore++;
        textLabel.text = currentScore.ToString();
    }
}

