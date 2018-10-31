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

	// Use this for initialization
	void Start () {
        generatedLerpDestination = transform.position;
        spotlightSuspicionValue = 0;
	}
	
    void StartSpotlightLerp()
    {
        generatedLerpDestination = new Vector3(Random.Range(spotlightLerpMin.x, spotlightLerpMax.x), transform.position.y, Random.Range(spotlightLerpMin.z,spotlightLerpMax.z));
    }

    

    // Update is called once per frame
    void Update () {
        if (transform.position == generatedLerpDestination)
        {
            StartSpotlightLerp();
        }

        float fracJourney = lerpSpeed / Vector3.Distance(transform.position, generatedLerpDestination);

        transform.position = Vector3.Lerp(transform.position, generatedLerpDestination, fracJourney);
	}
}
