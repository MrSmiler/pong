using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;


        GameState currentState;

        void Awake()
        {
            if (instance == null) 
            {
                instance = this;
                updateState(GameState.MainMenu);
            }
        }

        void Start()
        {
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
            var labels = GameObject.FindGameObjectsWithTag("ScoreLabel");
            foreach (var label in labels) 
            {
                Debug.Log(label);
                label.SetActive(false);
            }
            GameObject.FindGameObjectWithTag("GameStateObjects").GetComponent<BallSpawner>().enabled = false;
        }

        void HandleGameStartState()
        {
            var labels = GameObject.FindGameObjectsWithTag("ScoreLabel");
            foreach (var label in labels) 
            {
                label.SetActive(true);
            }
            GameObject.FindGameObjectWithTag("GameStateObjects").SetActive(true);
            GameObject.FindGameObjectWithTag("Timer").SetActive(false);
        }
    }

    public enum GameState
    {
        MainMenu,
        GameTimer,
        GameStart,
        GameOver,
        GamePause
    }
}