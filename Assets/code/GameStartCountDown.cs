using Game.Core;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameStartCountDown : MonoBehaviour
{
    public int countDown = 3;
    Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        StartCoroutine(Countdown());
    }
    private IEnumerator Countdown() {
        while (countDown > 0)
        {
            yield return new WaitForSeconds(1);
            countDown--;
            timerText.text = countDown.ToString();
        }
        GameManager.instance.updateState(GameState.GameStart);
        // Raise Event
    }

    // Update is called once per frame
    void Update()
    {

    }
}
