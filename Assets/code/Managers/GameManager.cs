using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Game.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        private GameObject[] labels;

        private GameState currentState;

        public GameState CurrentState { get { return currentState; } }

        void Awake()
        {
            if (instance == null) 
            {
                instance = this;
            }
        }

        void Start()
        {
            updateState(GameState.GameTimer);
        }

        public void updateState(GameState state)
        {
            currentState = state;

            switch (state)
            {
                case GameState.MainMenu:
                    HandleMainMenuState();
                    break;
                case GameState.GameTimer:
                    HandleGameTimerState();
                    break;
                case GameState.GameStart:
                    HandleGameStartState();
                    break;
                case GameState.GameOver:
                    break;
                case GameState.GamePause:
                    HandleGamePause();
                    break;
                case GameState.GameUnPause:
                    HandleGameUnPause();
                    break;
            }
        }

        void HandleMainMenuState()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene != "Menu")
            {
                SceneManager.LoadScene("Menu");
            }
        }
        void HandleGameTimerState()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            Debug.Log("before load scene");
            if (currentScene != "Main")
            {
                Debug.Log("in load scene");
                SceneManager.LoadScene("Main");
            }
            labels = GameObject.FindGameObjectsWithTag("ScoreLabel");
            foreach (var label in labels)
            {
                Debug.Log("label: " + label);
                label.SetActive(false);
            }
            GameObject.FindGameObjectWithTag("GameStateObjects").GetComponent<BallSpawner>().enabled = false;
            GameObject.FindGameObjectWithTag("Timer").SetActive(true);
        }

        void HandleGameStartState()
        {
            // labels = GameObject.FindGameObjectsWithTag("ScoreLabel");
            foreach (var label in labels)
            {
                Debug.Log("label: " + label);
                label.SetActive(true);
            }
            GameObject.FindGameObjectWithTag("Timer").SetActive(false);
            GameObject.FindGameObjectWithTag("GameStateObjects").GetComponent<BallSpawner>().enabled = true;
        }
        void HandleGamePause()
        {
            GameObject pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            if (pauseMenu == null)
            {
                throw new Exception("Pause Menu game object was not found");
            }

            pauseMenu.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
        void HandleGameUnPause()
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

    public enum GameState
    {
        MainMenu,
        GameTimer,
        GameStart,
        GameOver,
        GamePause,
        GameUnPause
    }
}