using System.Collections;
using Game.Core;
using UnityEngine;
using UnityEngine.UI;

public class GameStartCountDown : MonoBehaviour
{
    public int countDown = 3;
    private Text _timerText;

    // Start is called before the first frame update
    private void Start()
    {
        _timerText = GetComponent<Text>();
        StartCoroutine(Countdown());
    }
    private IEnumerator Countdown()
    {
        while (countDown > 0)
        {
            yield return new WaitForSeconds(1);
            countDown--;
            _timerText.text = countDown.ToString();
        }
        GameManager.instance.UpdateState(EGameState.GameStart);
        // Raise Event
    }
}
