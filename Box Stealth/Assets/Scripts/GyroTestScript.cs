using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.UI;

public class GyroTestScript : MonoBehaviour {

    Gyroscope gyro;
    HeadBobber headBobScript;
    Animator anim;
    PlayerSteps sound;
    public bool isThePlayerMoving;
    public float movementSlowdown;
    public float rotateSpeedUp;

    public GameObject CollectableUI;


    private float pickupScore;
    public float pickupMax;
    // Use this for initialization
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        headBobScript = Camera.main.GetComponent<HeadBobber>();
        sound = GetComponent<PlayerSteps>();
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", false);
        isThePlayerMoving = false;
        pickupScore = 0;
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Spotlight")
        {
            if (isThePlayerMoving == true)
            {
                other.gameObject.GetComponent<SpotlightController>().alertMarkObject.SetActive(true);
                other.gameObject.GetComponent<SpotlightController>().spotlightSuspicionValue++;
            }
            if (other.gameObject.GetComponent<SpotlightController>().spotlightSuspicionValue > 0)
            {
                
                other.gameObject.GetComponent<SpotlightController>().generatedLerpDestination = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
            }

            if (other.gameObject.GetComponent<SpotlightController>().spotlightSuspicionValue > 0 && isThePlayerMoving == false)
            {
                other.gameObject.GetComponent<SpotlightController>().spotlightSuspicionValue--;
            }
            
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Spotlight")
        {
            StartCoroutine(other.gameObject.GetComponent<SpotlightController>().DepreciateSuspicion());
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            pickupScore++;
            other.gameObject.GetComponent<PickupScript>().myCorrespondingUIElement.transform.GetChild(0).gameObject.SetActive(true);
            int pickupID = other.GetComponent<PickupScript>().id;
            Destroy(other.gameObject);
            sound.PickupGet(pickupID);
        }
    }



    // Update is called once per frame
    void FixedUpdate () {
       //transform.Rotate(gyro.rotationRateUnbiased.x, gyro.rotationRateUnbiased.y, gyro.rotationRateUnbiased.z);       

        


        if ((Mathf.Round(gyro.gravity.y * 100)) / 100.0 == -1)
        {
            headBobScript.StopBobbing();
            isThePlayerMoving = false;
            anim.SetBool("Walking", false);
        }
        else
        {
            
            isThePlayerMoving = true;
            transform.Translate(0, 0,  -transform.InverseTransformDirection(transform.forward).z * gyro.gravity.z / movementSlowdown);
            transform.Rotate(0, Mathf.Ceil(gyro.gravity.x*100)/100 * rotateSpeedUp, 0);
            headBobScript.StartBobbing();
            anim.SetBool("Walking", true);
        }
        //print(gyro.rotationRate);
        //print(Mathf.Ceil(gyro.gravity.x * 100) / 100);
        //print(Mathf.Ceil(gyro.rotationRateUnbiased.z));
       
    }
}
