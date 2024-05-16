using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            StartCoroutine(PlayDelayedSound());
        }
    }

    IEnumerator PlayDelayedSound()
    {
        yield return new WaitForSeconds(delay);

        audioSource.Play();
    }
}
