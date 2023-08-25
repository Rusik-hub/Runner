using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SpeedController _speedController;
    [SerializeField] private GroundMaterialController _groundMaterialController;

    private float _score;
    private float _requireScore;
    private float _requireScoreStep = 600;

    public float Score => _score;

    private void Update()
    {
        _score += _speedController.Speed * Time.deltaTime;
        _text.text = ((int)_score).ToString();

        if (_score >= _requireScore)
        {
            _requireScore += _requireScoreStep;
            _groundMaterialController.SetRandomMaterial();
        }
    }
}
