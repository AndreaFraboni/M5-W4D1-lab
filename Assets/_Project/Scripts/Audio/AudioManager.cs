using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public void SetVolume(float value, string group)
    {
        if (value > 0.01f)
        {
            float volume = Mathf.Log10(value) * 20;
            _mixer.SetFloat(group, volume);
        }
        else
        {
            _mixer.SetFloat(group, -80f);
        }
    }
    public void SetMasterVolume(float value)
    {
        SetVolume(value, "Master");
    }

    public void SetMusicVolume(float value)
    {
        SetVolume(value, "Music");
    }

    public void SetSFXVolume(float value)
    {
        SetVolume(value, "SFX");
    }

    public void PlayMusic(string name)
    {
        foreach (Sound _sound in musicSounds)
        {
            if (_sound.name == name)
            {
                if (musicSource.isPlaying) musicSource.Stop();
                musicSource.clip = _sound.clip;
                musicSource.Play();
                return;
            }
        }

        Debug.LogWarning($"Music Not Found in my list: {name}");
    }

    public void PlaySFX(string name)
    {
        foreach (Sound _sound in sfxSounds)
        {
            if (_sound.name == name)
            {
                sfxSource.PlayOneShot(_sound.clip);
                return;
            }
        }

        Debug.LogWarning($"SFX sound Not Found in my list: {name}");
    }

    public void StopAllAudioSource()
    {
        if (musicSource.isPlaying) musicSource.Stop();
        if (sfxSource.isPlaying) sfxSource.Stop();
    }
}
