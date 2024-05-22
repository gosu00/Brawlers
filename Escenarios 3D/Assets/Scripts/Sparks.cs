using UnityEngine;

public class Sparks : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public AudioSource audioSource;
    public float particleInterval = 5.0f;
    public float audioInterval = 2.0f;

    private float particleTimer;
    private float audioTimer;
    private float audioCount = 0;

    void Start()
    {
        particleTimer = particleInterval;
        audioTimer = audioInterval;
    }

    void Update()
    {
        particleTimer -= Time.deltaTime;
        audioTimer -= Time.deltaTime;

        if (particleTimer <= 0f)
        {
            particleSystem.Play();
            particleTimer = particleInterval;
            audioCount = 0;
        }

        if (audioTimer <= 0f && audioCount < 2)
        {
            audioCount++;
            audioSource.Play();
            audioTimer = audioInterval;
        }
    }
}
