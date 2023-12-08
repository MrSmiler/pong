using Game.Core;
using UnityEngine;
using UnityEngine.UI;

public class RigthRacketScoreTracker : MonoBehaviour
{
    // Start is called before the first frame update
    private Text _textLabel;

    private void Start()
    {
        _textLabel = GetComponent<Text>();
    }

    private void OnEnable()
    {
        GameEventManager.GetGameEventBus().SubscribeTo<LeftGoalTriggerdEvent>(RigthRacketScored);
    }

    private void OnDisable()
    {
        GameEventManager.GetGameEventBus().UnsubscribeFrom<LeftGoalTriggerdEvent>(RigthRacketScored);
    }

    private void RigthRacketScored(ref LeftGoalTriggerdEvent eventData)
    {
        int currentScore = int.Parse(_textLabel.text);
        currentScore++;
        _textLabel.text = currentScore.ToString();
    }
}
