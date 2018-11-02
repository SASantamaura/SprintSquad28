using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour {

    public Vector3 spotlightLerpMin;
    public Vector3 spotlightLerpMax;
    public Vector3 generatedLerpDestination;
    public float lerpSpeed;
    private float lerpStartTime;
    public float spotlightSuspicionValue;

    public GameObject detectionMeter;
    public GameObject alertMarkObject;

    public bool lockedOnToPlayer;

    AudioSource source;
    public AudioClip alarm;

    GameManagerScript manuscript;
    public GameObject manager;

    private void Awake()
    {
        lockedOnToPlayer = false;
        detectionMeter.GetComponent<RectTransform>().offsetMax = new Vector3(detectionMeter.GetComponent<RectTransform>().offsetMax.x, detectionMeter.GetComponent<RectTransform>().offsetMax.y, 0);
        manuscript = manager.GetComponent<GameManagerScript>();
        source = GetComponent<AudioSource>();
    }


    // Use this for initialization
    void Start() {
        generatedLerpDestination = transform.position;
        spotlightSuspicionValue = 0;
    }

    void StartSpotlightLerp()
    {
        generatedLerpDestination = new Vector3(Random.Range(spotlightLerpMin.x, spotlightLerpMax.x), transform.position.y, Random.Range(spotlightLerpMin.z, spotlightLerpMax.z));
    }

    public void UnmaskDetectionMeter()
    {
        detectionMeter.GetComponent<RectTransform>().offsetMax = new Vector3(detectionMeter.GetComponent<RectTransform>().offsetMax.x, spotlightSuspicionValue + detectionMeter.GetComponent<RectTransform>().offsetMin.y, 0);
    }

    public void CheckSpotlightSuspicion()
    {
        if (spotlightSuspicionValue == 0)
        {
            alertMarkObject.SetActive(false);
        }
    }

    public IEnumerator DepreciateSuspicion()
    {
        if (spotlightSuspicionValue > 0)
        {
            spotlightSuspicionValue--;
            yield return new WaitForSeconds(Time.deltaTime);
            StartCoroutine(DepreciateSuspicion());
        }       
    }

    // Update is called once per frame
    void Update () {
        
        if (transform.position == generatedLerpDestination)
        {
            StartSpotlightLerp();
        }

        UnmaskDetectionMeter();
        CheckSpotlightSuspicion();
        if(spotlightSuspicionValue >= 105)
        {
            source.PlayOneShot(alarm);
            manuscript.LoseGame();
        }

        float fracJourney = lerpSpeed / Vector3.Distance(transform.position, generatedLerpDestination);

        transform.position = Vector3.Lerp(transform.position, generatedLerpDestination, fracJourney);
	}
}
