using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SpeedController _speedController;

    private float _score;

    private void Update()
    {
        _score += _speedController.Speed * Time.deltaTime;
        _text.text = ((int)_score).ToString();
    }
}
