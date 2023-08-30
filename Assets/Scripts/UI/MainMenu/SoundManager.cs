using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _backgroundMusics;
    [SerializeField] private List<AudioSource> _gameSounds;
    [SerializeField] private Slider _music;
    [SerializeField] private Slider _sound;

    private float _musicVolume;
    private float _soundsVolume;

    public static SoundManager _soundManager;

    public void SetMusicVolume(float value)
    {
        _musicVolume = value;

        UpdateMusicVolume();
    }

    public void SetSoundVolume(float value)
    {
        _soundsVolume = value;

        UpdateSoundVolume();
    }

    private void Awake()
    {
        if (_soundManager != null)
        {
            Destroy(_soundManager);
        }

        _soundManager = GetComponent<SoundManager>();

        DontDestroyOnLoad(gameObject);
    }

    private void UpdateMusicVolume()
    {
        foreach (AudioSource music in _backgroundMusics)
        {
            music.volume = _musicVolume;
        }
    }

    private void UpdateSoundVolume()
    {
        foreach (AudioSource sound in _gameSounds)
        {
            sound.volume = _soundsVolume;
        }
    }
}
