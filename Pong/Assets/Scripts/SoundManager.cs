using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public enum SoundType
    {
        serve,
        goal,
        win
    }

    public AudioSource serveAudioSource;
    public AudioSource goalAudioSource;
    public AudioSource winAudioSource;

    public float minPitch;
    public float maxPitch;

    private void Awake()
    {
        Instance = this;

    }

    public void PlaySound(SoundType soundTypeToPlay)
    {
        AudioSource audioSourceToPlay;

        if(soundTypeToPlay == SoundType.serve)
        {
            audioSourceToPlay = serveAudioSource;
        }
        else if (soundTypeToPlay == SoundType.goal)
        {
            audioSourceToPlay = goalAudioSource;
        }
        else if (soundTypeToPlay == SoundType.win)
        {
            audioSourceToPlay = winAudioSource;
        }
        else
        {
            //set default audio source
            print("SoundType not found");
            audioSourceToPlay = serveAudioSource;
        }

        float rnadPitch = Random.Range(minPitch, maxPitch);
        audioSourceToPlay.pitch = rnadPitch;
        audioSourceToPlay.Play();
    }

}
