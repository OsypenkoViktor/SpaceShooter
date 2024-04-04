using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    private AudioSource[] audioSources;
    [Header("Asteroid Hits")]
    public List<AudioClip> asteriodHit;
    [Header("AsteroidExplosions")]
    public List<AudioClip> asteroidExplosions;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void PlayAsteroidHit()
    {
        AudioClip currentHitClip = asteriodHit[Random.Range(0,asteriodHit.Count)];
        PlayAudioClip(currentHitClip);
    }

    public void PlayAsteroidExplosion()
    {
        AudioClip currentExplosionClip = asteroidExplosions[Random.Range(0, asteroidExplosions.Count)];
        PlayAudioClip(currentExplosionClip);
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = audioClip;
                audioSource.Play();
                return;
            }
        }
    }
    
}
