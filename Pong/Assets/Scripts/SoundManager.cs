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

    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(SoundType soundTypeToPlay)
    {
        AudioSource audioSourceToPlay;

        if (soundTypeToPlay == SoundType.goal)
        {
            audioSourceToPlay = goalAudioSource;
        }
        else if (soundTypeToPlay == SoundType.win)
        {
            audioSourceToPlay = winAudioSource;
        }
        else if (soundTypeToPlay == SoundType.serve)
        {
            audioSourceToPlay = serveAudioSource;
        }
        else
        {
            //set default audio source
            audioSourceToPlay = goalAudioSource;
        }

        float randPitch = Random.Range(minPitch, maxPitch);
        audioSourceToPlay.pitch = randPitch;
        audioSourceToPlay.Play();
    }
}
