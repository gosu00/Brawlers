using UnityEngine;
using UnityEngine.Video;

public class VideoTrigger : MonoBehaviour
{
    [SerializeField] private GameObject image;
    public VideoClip videoClip;
    private VideoPlayer videoPlayer;
    private bool playerEntered;
    private bool playerEntered2;
    private bool hasPlayed = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        playerEntered = false;
        image.SetActive(false);

        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.targetTexture.Release();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered2 = true;
        }
    }

    void Update()
    {
        if (playerEntered && playerEntered2)
        {
            if (!videoPlayer.isPlaying && !hasPlayed)
            {
                image.SetActive(true);
                hasPlayed = true;
                videoPlayer.clip = videoClip;
                videoPlayer.Play();
            }
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        vp.Stop();

        vp.targetTexture.Release();
    }

    void OnDisable()
    {
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
