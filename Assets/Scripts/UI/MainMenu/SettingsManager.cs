using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private float _musicVolume;
    private float _gameSoundsVolume;

    public float MusicVolume => _musicVolume;
    public float GameSoundsVolume => _gameSoundsVolume;

    public void SetMusicVolume(float value)
    {
        _musicVolume = value;
    }

    public void SetSoundsVolume(float value)
    {
        _gameSoundsVolume = value;
    }
}
