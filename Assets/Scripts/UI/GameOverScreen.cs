using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;

    private CanvasGroup _canvasGroup;

    private void ShowScreen()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    private void HideScreen()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        _retryButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(OpenMainMenu);
        _player.Dead += ShowScreen;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        HideScreen();
    }

    private void OnDisable()
    {
        _retryButton.onClick.RemoveListener(RestartGame);
        _exitButton.onClick.RemoveListener(OpenMainMenu);
        _player.Dead -= ShowScreen;
    }
}
