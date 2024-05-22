using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public float speed = 0.5f; // Velocidad de parpadeo
    public float intensity = 1.0f; // Intensidad máxima de la luz
    private float flickerIntensity; // Intensidad actual de la luz

    void Start()
    {
        flickerIntensity = intensity; // Inicializar intensidad actual
    }

    void Update()
    {
        flickerIntensity = Mathf.Sin(Time.time * speed) * intensity; // Modificar intensidad
        GetComponent<Light>().intensity = flickerIntensity; // Aplicar intensidad a la luz
    }
}