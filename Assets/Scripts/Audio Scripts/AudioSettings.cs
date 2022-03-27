using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public static AudioSettings instance = null;

    FMOD.Studio.EventInstance sfxVolumeTestEvent;

    FMOD.Studio.Bus music;
    FMOD.Studio.Bus sfx;

    public float musicVolume;
    public float sfxVolume;
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;            
        }

        DontDestroyOnLoad(gameObject.transform);

        musicVolume = 0.5f;
        sfxVolume = 0.5f;

        music = FMODUnity.RuntimeManager.GetBus("bus:/Music");
        sfx = FMODUnity.RuntimeManager.GetBus("bus:/FX");
        sfxVolumeTestEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Fx/Puzzle Complete");
    }

    void Update()
    {
        music.setVolume(musicVolume);
        sfx.setVolume(sfxVolume);
    }

    public void MusicVolumeLevel (float newMusicVolume)
    {
        musicVolume = newMusicVolume;
    }
    public void SFXVolumeLevel(float newSFXVolume)
    {
        sfxVolume = newSFXVolume;

        FMOD.Studio.PLAYBACK_STATE PbState;
        sfxVolumeTestEvent.getPlaybackState(out PbState);
        if (PbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            sfxVolumeTestEvent.start();
        }
    }
}
