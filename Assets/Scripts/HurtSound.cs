using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSound : MonoBehaviour
{
// Reference to the AudioSource component
    public AudioSource audioSource;
    
    private void OnTriggerEnter(Collider collision)
    {
        // Play the sound on collision
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
