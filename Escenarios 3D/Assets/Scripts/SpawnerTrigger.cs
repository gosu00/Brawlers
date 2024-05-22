using UnityEngine;
using System.Collections;

public class SpawnerTrigger : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Quaternion rotation;
    [SerializeField] private GameObject disable;
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private float speed = 2f;
    [SerializeField] GameObject flashLight;

    private bool hasPlayed = false;
    private bool hasMoved = false;
    private bool hasDisabled = false;
    private bool hasHit = false;
    private float flashLightIntensity;

    private void Start()
    {
        flashLightIntensity = flashLight.GetComponent<Light>().intensity;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == spawnPrefab)
            {
                if (!hasMoved)
                {
                    hasMoved = true;
                    StartCoroutine(StartMove());
                    StartCoroutine(Disable());
                }
            }
        }

        if (hasHit) spawnPrefab.transform.position = Vector3.MoveTowards(spawnPrefab.transform.position, finalPosition, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            gameObject.GetComponentInChildren<PlayAudio>().PlayAudioClip();
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator StartMove()
    {
        yield return new WaitForSeconds(0.5f);
        hasHit = true;
        spawnPrefab.GetComponent<PlayAudio>().PlayAudioClip();
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(2f);
        spawnPrefab.SetActive(false);
        Destroy(spawnPrefab);
        hasHit = false;
        //flashLight.GetComponent<FlickerLight1>().enabled = false;
        //flashLight.GetComponent<Light>().intensity = flashLightIntensity;
        Destroy(gameObject);
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(delay);
        disable.SetActive(false);
        spawnPrefab = Instantiate(spawnPrefab, spawnPosition, rotation);
        //flashLight.GetComponent<FlickerLight1>().enabled = true;
    }
}
