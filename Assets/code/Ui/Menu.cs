using Game.Core;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public void SinglePlayerClicked()
    {
        // SceneManager.LoadScene("Main");
        GameManager.instance.UpdateState(EGameState.GameTimer);
    }
    public void TwoPlayerKeyboardClicked()
    {
    }

    public void TwoPlayerNetworkClicked()
    {
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
