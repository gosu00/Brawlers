using UnityEngine;

public class Sparks : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        particleSystem.Play();
        audioSource.Play();
    }
}
