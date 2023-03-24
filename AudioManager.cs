using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public AudioSource audiorenaissance;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GameController"))
        {
            audioSource.Stop();
        }
    }

    void Start()
    {
        
        
    audioSource.clip = playlist[0];
    audioSource.Play();
        
    }
}
