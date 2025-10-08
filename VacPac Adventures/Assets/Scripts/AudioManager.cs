using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource sfxSource;

    public List<AudioClip> sfxClips;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlaySound("SlimeJump", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlaySound("SlimeDeath", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlaySound("Spike", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlaySound("SlimeStream", true);
        }
    }

    public void PlaySound(string clipName, bool isLoop)
    {
        AudioClip clip = sfxClips.Find(c => c.name == clipName);

        if (isLoop)
        {
            sfxSource.loop = true;
        }
        else
        {
            sfxSource.loop = false;
        }

        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning($"SFX clip '{clipName}' not found.");
        }
    }

    public void StopSound()
    {
        sfxSource.Stop();
    }
}
