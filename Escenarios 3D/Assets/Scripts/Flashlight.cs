using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        flashlight.enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        if (audioSource) audioSource.Play();

        flashlight.enabled = !flashlight.enabled;
    }
}
