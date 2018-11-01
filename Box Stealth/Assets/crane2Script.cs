using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crane2Script : MonoBehaviour {

    public GameObject spotlight;
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(spotlight.transform.position.x, transform.position.y, transform.position.z);
	}
}
