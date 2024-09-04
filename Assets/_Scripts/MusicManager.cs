using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    public static MusicManager Instance { get; private set; }

    [SerializeField] AudioClip _mainMenuMusic;
    [SerializeField] AudioClip _adventureMusic;

    private AudioSource _audioSource;

    private void Awake() {
        if (Instance != null) { Debug.LogError("There is more than one MusicManager instance!"); }
        Instance = this;

        if (!_audioSource) { _audioSource = GetComponent<AudioSource>(); }
    }

    public void MainMenuMusic() {
        _audioSource.clip = _mainMenuMusic;
        _audioSource.Play();
    }

    public void AdventureMusic() {
        _audioSource.clip = _adventureMusic;
        _audioSource.Play();
    }

    public void IsPaused(bool isPaused) {
        if (isPaused) { _audioSource.Pause(); }
        else { _audioSource.UnPause(); }
    }
}