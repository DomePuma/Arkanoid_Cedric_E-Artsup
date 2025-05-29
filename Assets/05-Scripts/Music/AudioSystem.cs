using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BrickBreaker.Audio.Music.Type;

namespace BrickBreaker.Audio.Music
{
    public class AudioSystem : MonoBehaviour
    {
        public static AudioSystem Instance { get; private set; }

        [Header("Audio Source")]
        [SerializeField] private AudioSource _musicSource;

        [Header("Clips par type")]
        [SerializeField] private MusicType[] _musicKeyArray;
        [SerializeField] private AudioClip[] _musicClipArray;

        private Dictionary<MusicType, AudioClip> _musicDict = new();

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            for (int i = 0; i < _musicKeyArray.Length && i < _musicClipArray.Length; i++)
            {
                if (!_musicDict.ContainsKey(_musicKeyArray[i]) && _musicClipArray[i] != null)
                    _musicDict[_musicKeyArray[i]] = _musicClipArray[i];
            }

            SceneManager.sceneLoaded += OnSceneLoaded;

            FindAndSetMusicSource();
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            FindAndSetMusicSource();
        }

        private void FindAndSetMusicSource()
        {
            MenuMusic menuMusic = FindFirstObjectByType<MenuMusic>();

            if (menuMusic != null)
            {
                AudioSource source = menuMusic.GetComponent<AudioSource>();
                if (source != null)
                {
                    _musicSource = source;
                    Debug.Log("AudioSource mis à jour depuis MenuMusic dans la scène " + SceneManager.GetActiveScene().name);
                }
                else
                {
                    Debug.LogWarning("AudioSource non trouvé sur MenuMusic GameObject.");
                }
            }
            else
            {
                Debug.LogWarning("MenuMusic non trouvé en scène " + SceneManager.GetActiveScene().name);
            }
        }

        public void PlayMusic(MusicType type, bool loop = true)
        {
            if (_musicSource == null)
            {
                Debug.LogWarning("AudioSource non assigné. Impossible de jouer la musique.");
                return;
            }

            if (_musicDict.TryGetValue(type, out var clip))
            {
                _musicSource.clip = clip;
                _musicSource.loop = loop;
                _musicSource.Play();
            }
            else
            {
                Debug.LogWarning($"Musique '{type}' non trouvée.");
            }
        }

        public void StopMusic() => _musicSource?.Stop();
        public void PauseMusic() => _musicSource?.Pause();
        public void ResumeMusic() => _musicSource?.UnPause();
    }
}