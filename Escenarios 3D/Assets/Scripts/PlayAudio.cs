using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void PlayAudioClip()
    {
        audioSource.Play();
    }
}
