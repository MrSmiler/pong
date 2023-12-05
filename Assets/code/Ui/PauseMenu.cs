using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using Game.Core;
using JetBrains.Annotations;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResumeButtonHandler()
    {
        GameManager.instance.updateState(GameState.GameUnPause);
    }

    public void RestartButtonHandler()
    {
        GameManager.instance.updateState(GameState.GameTimer);
    }

    public void MainMenuButtonHandler()
    {
        GameManager.instance.updateState(GameState.MainMenu);
    }

    public void SettingMenuButtonHandler()
    {
    
    }

}
