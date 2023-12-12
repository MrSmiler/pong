using Game.Core;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public void SinglePlayerClicked()
    {
        // SceneManager.LoadScene("Main");
        GameManager.instance.CurrentPlayMode = EPlayMode.Single;
        GameManager.instance.UpdateState(EGameState.GameTimer);
    }
    public void TwoPlayerKeyboardClicked()
    {
        GameManager.instance.CurrentPlayMode = EPlayMode.TwoSameKeyboard;
        GameManager.instance.UpdateState(EGameState.GameTimer);
    }

    public void TwoPlayerNetworkClicked()
    {
        GameManager.instance.CurrentPlayMode = EPlayMode.TwoNetwork;
        GameManager.instance.UpdateState(EGameState.GameTimer);
    }

    public void SettingsClicked()
    {
    }

    public void ExitClicked()
    {
        Application.Quit();
#if DEBUG
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
