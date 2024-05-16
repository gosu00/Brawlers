using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform camRotation;
    [SerializeField] private Camera cam;
    [SerializeField] Material material;
    [SerializeField] private float rotationSpeed = 5;

    private bool isBlinking = true;
    public float minIntensity = 0.1f;
    public float maxIntensity = 2.0f;
    public float blinkSpeed = 2.0f;

    private void Start()
    {
        StartCoroutine(Blink());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            camRotation.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
            cameraTransform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.J))
        {
            camRotation.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.World);
            cameraTransform.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.I))
        {
            cameraTransform.Rotate(-rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.K))
        {
            cameraTransform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.U))
        {
            cam.fieldOfView += 1;
        }
        if (Input.GetKey(KeyCode.O))
        {
            cam.fieldOfView -= 1;
        }

    }

    IEnumerator Blink()
    {
        while (isBlinking)
        {
            float lerp = Mathf.PingPong(Time.time * blinkSpeed, 1.0f);
            float intensity = Mathf.Lerp(minIntensity, maxIntensity, lerp);

            material.SetColor("_EmissiveColor", Color.red * intensity);

            yield return null;
        }
    }
}
