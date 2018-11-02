using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    public GameObject myCorrespondingUIElement;
    public float turnSpeed;
    public int id;
	// Use this for initialization
	
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
