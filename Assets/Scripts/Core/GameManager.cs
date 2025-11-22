using UnityEngine;
using UnityEngine.SceneManagement;

namespace AdventuresOfTheWorld.Core
{
    /// <summary>
    /// Main game manager - handles game state, pausing, and scene management.
    /// Singleton pattern for global access.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("GameManager");
                        _instance = go.AddComponent<GameManager>();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Game State

        public enum GameState
        {
            MainMenu,
            Playing,
            Paused,
            LevelComplete,
            GameOver
        }

        private GameState _currentState = GameState.MainMenu;
        public GameState CurrentState => _currentState;

        #endregion

        #region Properties

        public bool IsPaused => _currentState == GameState.Paused;
        public bool IsPlaying => _currentState == GameState.Playing;

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            // Singleton setup
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            // Initialize game
            Application.targetFrameRate = 60; // Target 60 FPS
        }

        private void Update()
        {
            HandlePauseInput();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts a new game level
        /// </summary>
        public void StartLevel(string levelName)
        {
            Time.timeScale = 1f;
            _currentState = GameState.Playing;
            SceneManager.LoadScene(levelName);
        }

        /// <summary>
        /// Starts a level by build index
        /// </summary>
        public void StartLevel(int levelIndex)
        {
            Time.timeScale = 1f;
            _currentState = GameState.Playing;
            SceneManager.LoadScene(levelIndex);
        }

        /// <summary>
        /// Pauses the game
        /// </summary>
        public void PauseGame()
        {
            if (_currentState == GameState.Playing)
            {
                _currentState = GameState.Paused;
                Time.timeScale = 0f;

                // Optional: Show pause menu
                // UIManager.Instance?.ShowPauseMenu();
            }
        }

        /// <summary>
        /// Resumes the game from pause
        /// </summary>
        public void ResumeGame()
        {
            if (_currentState == GameState.Paused)
            {
                _currentState = GameState.Playing;
                Time.timeScale = 1f;

                // Optional: Hide pause menu
                // UIManager.Instance?.HidePauseMenu();
            }
        }

        /// <summary>
        /// Restarts the current level
        /// </summary>
        public void RestartLevel()
        {
            Time.timeScale = 1f;
            _currentState = GameState.Playing;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /// <summary>
        /// Called when level is completed
        /// </summary>
        public void CompleteLevel()
        {
            _currentState = GameState.LevelComplete;

            // Optional: Show level complete screen
            // UIManager.Instance?.ShowLevelCompleteScreen();
        }

        /// <summary>
        /// Called when player runs out of lives
        /// </summary>
        public void GameOver()
        {
            _currentState = GameState.GameOver;

            // Optional: Show game over screen
            // UIManager.Instance?.ShowGameOverScreen();
        }

        /// <summary>
        /// Loads the main menu
        /// </summary>
        public void LoadMainMenu()
        {
            Time.timeScale = 1f;
            _currentState = GameState.MainMenu;
            SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        /// Quits the game
        /// </summary>
        public void QuitGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        #endregion

        #region Private Methods

        private void HandlePauseInput()
        {
            // ESC key to pause/unpause
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_currentState == GameState.Playing)
                {
                    PauseGame();
                }
                else if (_currentState == GameState.Paused)
                {
                    ResumeGame();
                }
            }
        }

        #endregion
    }
}
