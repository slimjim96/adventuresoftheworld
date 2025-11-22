using UnityEngine;
using System.Collections.Generic;

namespace AdventuresOfTheWorld.Managers
{
    /// <summary>
    /// Manages all audio playback - background music and sound effects.
    /// Singleton pattern for global access.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        #region Singleton

        private static AudioManager _instance;
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<AudioManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("AudioManager");
                        _instance = go.AddComponent<AudioManager>();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Serialized Fields

        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        [Header("Volume Settings")]
        [SerializeField] [Range(0f, 1f)] private float masterVolume = 1f;
        [SerializeField] [Range(0f, 1f)] private float musicVolume = 0.8f;
        [SerializeField] [Range(0f, 1f)] private float sfxVolume = 1f;

        #endregion

        #region Private Fields

        private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

        #endregion

        #region Properties

        public float MasterVolume
        {
            get => masterVolume;
            set
            {
                masterVolume = Mathf.Clamp01(value);
                UpdateVolumes();
                SaveVolumeSettings();
            }
        }

        public float MusicVolume
        {
            get => musicVolume;
            set
            {
                musicVolume = Mathf.Clamp01(value);
                UpdateVolumes();
                SaveVolumeSettings();
            }
        }

        public float SFXVolume
        {
            get => sfxVolume;
            set
            {
                sfxVolume = Mathf.Clamp01(value);
                UpdateVolumes();
                SaveVolumeSettings();
            }
        }

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeAudioSources();
            LoadVolumeSettings();
            LoadAudioClips();
        }

        #endregion

        #region Initialization

        private void InitializeAudioSources()
        {
            // Create music audio source if not assigned
            if (musicSource == null)
            {
                GameObject musicObj = new GameObject("MusicSource");
                musicObj.transform.SetParent(transform);
                musicSource = musicObj.AddComponent<AudioSource>();
                musicSource.loop = true;
                musicSource.playOnAwake = false;
            }

            // Create SFX audio source if not assigned
            if (sfxSource == null)
            {
                GameObject sfxObj = new GameObject("SFXSource");
                sfxObj.transform.SetParent(transform);
                sfxSource = sfxObj.AddComponent<AudioSource>();
                sfxSource.loop = false;
                sfxSource.playOnAwake = false;
            }

            UpdateVolumes();
        }

        private void LoadAudioClips()
        {
            // Load all audio clips from Resources/Audio folder
            // This is a placeholder - in production, you'd load from Resources or Asset Bundles

            // Example:
            // AudioClip jumpClip = Resources.Load<AudioClip>("Audio/SFX/jump");
            // if (jumpClip != null) _audioClips["Jump"] = jumpClip;
        }

        #endregion

        #region Music Methods

        /// <summary>
        /// Plays background music
        /// </summary>
        public void PlayMusic(AudioClip clip)
        {
            if (clip == null) return;

            musicSource.clip = clip;
            musicSource.Play();
        }

        /// <summary>
        /// Plays music by name (from Resources)
        /// </summary>
        public void PlayMusic(string clipName)
        {
            AudioClip clip = Resources.Load<AudioClip>($"Audio/Music/{clipName}");
            if (clip != null)
            {
                PlayMusic(clip);
            }
            else
            {
                Debug.LogWarning($"AudioManager: Music clip '{clipName}' not found!");
            }
        }

        /// <summary>
        /// Stops currently playing music
        /// </summary>
        public void StopMusic()
        {
            musicSource.Stop();
        }

        /// <summary>
        /// Pauses music
        /// </summary>
        public void PauseMusic()
        {
            musicSource.Pause();
        }

        /// <summary>
        /// Resumes paused music
        /// </summary>
        public void ResumeMusic()
        {
            musicSource.UnPause();
        }

        #endregion

        #region SFX Methods

        /// <summary>
        /// Plays a sound effect
        /// </summary>
        public void PlaySFX(AudioClip clip)
        {
            if (clip == null) return;

            sfxSource.PlayOneShot(clip, sfxVolume * masterVolume);
        }

        /// <summary>
        /// Plays SFX by name (from Resources)
        /// </summary>
        public void PlaySFX(string clipName)
        {
            AudioClip clip = Resources.Load<AudioClip>($"Audio/SFX/{clipName}");
            if (clip != null)
            {
                PlaySFX(clip);
            }
            else
            {
                Debug.LogWarning($"AudioManager: SFX clip '{clipName}' not found!");
            }
        }

        /// <summary>
        /// Plays SFX with custom volume
        /// </summary>
        public void PlaySFX(AudioClip clip, float volume)
        {
            if (clip == null) return;

            sfxSource.PlayOneShot(clip, volume * sfxVolume * masterVolume);
        }

        #endregion

        #region Volume Control

        private void UpdateVolumes()
        {
            if (musicSource != null)
            {
                musicSource.volume = musicVolume * masterVolume;
            }

            if (sfxSource != null)
            {
                sfxSource.volume = sfxVolume * masterVolume;
            }
        }

        private void SaveVolumeSettings()
        {
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
            PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
            PlayerPrefs.Save();
        }

        private void LoadVolumeSettings()
        {
            masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.8f);
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

            UpdateVolumes();
        }

        #endregion
    }
}
