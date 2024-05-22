using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip openSound;
    public AudioClip closeSound;
    private bool isPlayerNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            animator.SetTrigger("OpenDoor");
            audioSource.PlayOneShot(openSound);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            animator.SetTrigger("CloseDoor");
            audioSource.PlayOneShot(closeSound);
        }
    }
}
