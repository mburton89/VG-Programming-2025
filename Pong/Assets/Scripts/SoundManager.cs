using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    public enum SoundType
    {
        spawn,
        win,
        goal,
        hit
    }

    public AudioSource spawnAudioSource;
    public AudioSource hitAudioSource;
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

        if(soundTypeToPlay == SoundType.goal)
        {
            audioSourceToPlay = goalAudioSource;
        }        
        else if(soundTypeToPlay == SoundType.spawn)
        {
            audioSourceToPlay = spawnAudioSource;
        }
        else if (soundTypeToPlay == SoundType.hit)
        {
            audioSourceToPlay = hitAudioSource;
        }
        else if (soundTypeToPlay == SoundType.win)
        {
            audioSourceToPlay = winAudioSource;
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
