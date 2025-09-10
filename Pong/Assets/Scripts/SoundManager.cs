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
        win,
    }

    public AudioSource serveAudioSouce;
    public AudioSource goalAudioSouce;
    public AudioSource winAudioSouce;

    public float minPitch = 0.9f;
    public float maxPitch = 1.1f;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(SoundType soundTypeToPlay)
    {
        AudioSource audioSourceToPlay;

        if(soundTypeToPlay == SoundType.serve)
        {
            audioSourceToPlay = serveAudioSouce;
        }        
        else if(soundTypeToPlay == SoundType.goal)
        {
            audioSourceToPlay = goalAudioSouce;
        }        
        else if(soundTypeToPlay == SoundType.win)
        {
            audioSourceToPlay = winAudioSouce;
        }
        else
        {
            //set any audio source
            audioSourceToPlay = null;
        }

        float randPitch = Random.Range(minPitch, maxPitch);

        audioSourceToPlay.pitch = randPitch;

        audioSourceToPlay.Play();
    }
}
