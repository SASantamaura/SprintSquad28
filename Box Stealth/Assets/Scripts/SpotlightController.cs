using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour {

    public Vector3 spotlightLerpMin;
    public Vector3 spotlightLerpMax;
    private Vector3 generatedLerpDestination;
    public float lerpSpeed;
    private float lerpStartTime;

	// Use this for initialization
	void Start () {
        generatedLerpDestination = transform.position;
	}
	
    void StartSpotlightLerp()
    {
        generatedLerpDestination = new Vector3(Random.Range(spotlightLerpMin.x, spotlightLerpMax.x), transform.position.y, Random.Range(spotlightLerpMin.z,spotlightLerpMax.z));
    }


    // Distance moved = time * speed.
    

    // Fraction of journey completed = current distance divided by total distance.
    


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
