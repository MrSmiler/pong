using Game.Core;
using UnityEngine;
using UnityEngine.UI;

public class LeftRacketScoreTracker : MonoBehaviour
{
    private Text _textLabel;

    private void Start()
    {
        _textLabel = GetComponent<Text>();
    }

    private void OnEnable()
    {
        GameEventManager.GetGameEventBus().SubscribeTo<RightGoalTriggerdEvent>(LeftRacketScored);
    }

    private void OnDisable()
    {
        GameEventManager.GetGameEventBus().UnsubscribeFrom<RightGoalTriggerdEvent>(LeftRacketScored);
    }

    private void LeftRacketScored(ref RightGoalTriggerdEvent eventData)
    {
        int currentScore = int.Parse(_textLabel.text);
        currentScore++;
        _textLabel.text = currentScore.ToString();
    }
}

