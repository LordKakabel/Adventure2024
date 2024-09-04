using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI _winText;
    [SerializeField] TextMeshProUGUI _gameOverText;
    [SerializeField] GameObject _menuPanel;
    [SerializeField] Button _startButton;
    [SerializeField] Button _quitButton;

    private enum GameState { Menu, Game, Paused }
    private GameState _gameState = GameState.Menu;

    private void Awake() {
        if (Instance != null) { Debug.LogError("There is more than one UIManager instance!"); }
        Instance = this;

        _winText.enabled = false;
        _gameOverText.enabled = false;
    }

    private void Start() {
        Time.timeScale = 0;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            switch (_gameState) {
                case GameState.Menu:
                    QuitGame();
                    break;
                case GameState.Game:
                    TogglePause();
                    break;
                case GameState.Paused:
                    TogglePause();
                    break;
                default:
                    break;
            }
        }

    }

    public void WinScreen() {
        _winText.enabled = true;
        Time.timeScale = 0;
    }

    public void GameOverScreen() {
        _gameOverText.enabled = true;
        Time.timeScale = 0;
    }

    public void StartGame() {
        _menuPanel.SetActive(false);
        _gameState = GameState.Game;
        MusicManager.Instance.AdventureMusic();
        Time.timeScale = 1;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void TogglePause() {
        if (_gameState == GameState.Paused) {
            _gameState = GameState.Game;
            Time.timeScale = 1;
            MusicManager.Instance.IsPaused(false);
        } else {
            _gameState = GameState.Paused;
            Time.timeScale = 0;
            MusicManager.Instance.IsPaused(true);
        }
    }
}