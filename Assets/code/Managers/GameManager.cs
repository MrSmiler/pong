using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private GameObject[] _labels;

        public EGameState CurrentState { get; private set; }
        public EPlayMode CurrentPlayMode { get; set; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            CurrentPlayMode = EPlayMode.Single;
        }

        private void Start()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene != "Menu")
            {
                UpdateState(EGameState.GameTimer);
            }
        }

        public void UpdateState(EGameState state)
        {
            if (CurrentState == EGameState.GamePause && state == EGameState.GameUnPause)
            {
                UnPauseGame();
            }

            CurrentState = state;

            switch (state)
            {
                case EGameState.MainMenu:
                    HandleMainMenuState();
                    break;
                case EGameState.GameTimer:
                    HandleGameTimerState();
                    break;
                case EGameState.GameStart:
                    HandleGameStartState();
                    break;
                case EGameState.GameOver:
                    break;
                case EGameState.GamePause:
                    HandleGamePause();
                    break;
                case EGameState.GameUnPause:
                    HandleGameUnPause();
                    break;
                default:
                    break;
            }
        }

        private void HandleMainMenuState()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene != "Menu")
            {
                SceneManager.LoadScene("Menu");
            }
        }
        private void HandleGameTimerState()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            Debug.Log("before load scene");
            if (currentScene != "Main")
            {
                Debug.Log("in load scene");
                SceneManager.LoadScene("Main");
            }
            _labels = GameObject.FindGameObjectsWithTag("ScoreLabel");
            foreach (var label in _labels)
            {
                Debug.Log("label: " + label);
                label.SetActive(false);
            }
            GameObject.FindGameObjectWithTag("GameStateObjects").GetComponent<BallSpawner>().enabled = false;
            GameObject.FindGameObjectWithTag("Timer").SetActive(true);
        }

        private void HandleGameStartState()
        {
            // labels = GameObject.FindGameObjectsWithTag("ScoreLabel");
            foreach (var label in _labels)
            {
                Debug.Log("label: " + label);
                label.SetActive(true);
            }
            GameObject.FindGameObjectWithTag("Timer").SetActive(false);
            GameObject.FindGameObjectWithTag("GameStateObjects").GetComponent<BallSpawner>().enabled = true;
        }
        private void HandleGamePause()
        {
            PauseGame();
        }
        private void HandleGameUnPause()
        {
            UnPauseGame();
        }

        private void PauseGame()
        {
            GameObject pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            if (pauseMenu == null)
            {
                throw new Exception("Pause Menu game object was not found");
            }

            pauseMenu.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }

        private void UnPauseGame()
        {
            GameObject pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            if (pauseMenu == null)
            {
                throw new Exception("Pause Menu game object was not found");
            }

            pauseMenu.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
    }

    public enum EGameState
    {
        MainMenu,
        GameTimer,
        GameStart,
        GameOver,
        GamePause,
        GameUnPause
    }

    public enum EPlayMode
    {
        Single,
        TwoSameKeyboard,
        TwoNetwork
    }
}
