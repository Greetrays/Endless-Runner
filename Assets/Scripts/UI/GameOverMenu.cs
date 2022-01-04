using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(CanvasGroup))]

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverGroup;

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Died += OnEnablePanel;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _backToMenuButton.onClick.AddListener(OnBackToMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnEnablePanel;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _backToMenuButton.onClick.RemoveListener(OnBackToMenuButtonClick);
    }

    private void OnEnablePanel()
    {
        _gameOverGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void OnBackToMenuButtonClick()
    {

    }
}
