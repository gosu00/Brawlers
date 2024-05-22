using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public float speed = 0.5f;
    public float intensity = 1.0f;
    private float flickerIntensity;

    void Start()
    {
        flickerIntensity = intensity;
    }

    void Update()
    {
        flickerIntensity = Mathf.Sin(Time.time * speed) * intensity;
        GetComponent<Light>().intensity = flickerIntensity;
    }
}