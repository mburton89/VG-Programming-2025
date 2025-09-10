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

    public void Awake()
    {
        Instance = this;
    }

    public void PlaySound(SoundType soundtypeToPlay)
    {
        AudioSource audioSourceToPlay;

        if (soundtypeToPlay == SoundType.goal)
        { 
            audioSourceToPlay = goalAudioSource;
        }
        else if (soundtypeToPlay == SoundType.serve)
        {
            audioSourceToPlay = serveAudioSource;
        }
        else if (soundtypeToPlay == SoundType.win)
        {
            audioSourceToPlay = winAudioSource;
        }
        else
        {
            //set to any default audio source
            audioSourceToPlay = goalAudioSource;
        }

        float randPitch = Random.Range(minPitch, maxPitch);
        audioSourceToPlay.pitch = randPitch;


        audioSourceToPlay.Play();
    }
}
