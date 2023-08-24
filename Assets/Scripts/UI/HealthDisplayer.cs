using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _value;
    
    public void DisplayHealth()
    {
        _value.text = _player.Health.ToString();
    }

    private void OnEnable()
    {
        _player.IsHealthUpdated += DisplayHealth;
    }

    private void OnDisable()
    {
        _player.IsHealthUpdated -= DisplayHealth;
    }
}
