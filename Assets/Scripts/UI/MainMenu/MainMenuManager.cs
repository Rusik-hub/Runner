using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private SettingsWindow _settingsWindow;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
        _settingsButton.onClick.AddListener(OpenSettingsWindow);
        _exitButton.onClick.AddListener(CloseGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(StartGame);
        _settingsButton.onClick.RemoveListener(OpenSettingsWindow);
        _exitButton.onClick.RemoveListener(CloseGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void CloseGame()
    {
        Debug.Log("Игра закрылась!");

        Application.Quit();
    }

    private void OpenSettingsWindow()
    {
        _settingsWindow.OpenWindow();
    }
}
