using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class GyroTestScript : MonoBehaviour {

    Gyroscope gyro;
    HeadBobber headBobScript;
    Animator anim;
    public bool isThePlayerMoving;
    public float movementSlowdown;
    public float rotateSpeedUp;
    // Use this for initialization
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        headBobScript = Camera.main.GetComponent<HeadBobber>();
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", false);
        isThePlayerMoving = false;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.name == "Spotlight")
        {
            print("b");
            if (isThePlayerMoving == true)
            {
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


    // Update is called once per frame
    void FixedUpdate () {
       //transform.Rotate(gyro.rotationRateUnbiased.x, gyro.rotationRateUnbiased.y, gyro.rotationRateUnbiased.z);       

        if ((Mathf.Round(gyro.gravity.y * 100)) / 100.0 == -1)
        {
            print("my dude");
            headBobScript.StopBobbing();
            isThePlayerMoving = false;
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
        print(gyro.gravity);
    }
}
