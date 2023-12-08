using Game.Core;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResumeButtonHandler()
    {
        GameManager.instance.UpdateState(EGameState.GameUnPause);
    }

    public void RestartButtonHandler()
    {
        GameManager.instance.UpdateState(EGameState.GameTimer);
    }

    public void MainMenuButtonHandler()
    {
        GameManager.instance.UpdateState(EGameState.MainMenu);
    }

    public void SettingMenuButtonHandler()
    {

    }

}
