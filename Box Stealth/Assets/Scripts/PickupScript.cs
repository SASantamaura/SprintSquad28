using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    public GameObject myCorrespondingUIElement;
    public float turnSpeed;

	// Use this for initialization
	void Awake () {
		


	}
	
    public void ReceiveUIElement(GameObject element)
    {
        myCorrespondingUIElement = element;
    }

	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
		
	}
}
