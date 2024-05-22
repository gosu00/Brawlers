using UnityEngine;

public class FlickerLight1 : MonoBehaviour
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
        speed = Random.Range(0.2f, 0.8f);

        flickerIntensity = Mathf.Sin(Time.time * speed) * intensity + Random.Range(-0.2f, 0.2f);

        GetComponent<Light>().intensity = flickerIntensity; 
    }
}