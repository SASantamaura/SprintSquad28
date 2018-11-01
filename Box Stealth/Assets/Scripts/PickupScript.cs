using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    public GameObject myCorrespondingUIElement;

	// Use this for initialization
	void Awake () {
		


	}
	
    public void ReceiveUIElement(GameObject element)
    {
        myCorrespondingUIElement = element;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
