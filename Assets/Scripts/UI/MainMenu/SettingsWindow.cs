using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private CanvasGroup _canvasGroup;

    public void OpenWindow()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        _canvasGroup.alpha = 1;
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(CloseWindow);
    }

    private void CloseWindow()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        _canvasGroup.alpha = 0;
    }
}
