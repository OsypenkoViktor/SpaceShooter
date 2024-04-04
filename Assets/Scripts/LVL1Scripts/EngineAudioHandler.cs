using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudioHandler : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreasePitch()
    {
        audioSource.pitch = 1.1f;
    }

    public void DecreasePitch()
    {
        audioSource.pitch = 0.9f;
    }

    public void ResetPitch()
    {
        audioSource.pitch = 1f;
    }

}
