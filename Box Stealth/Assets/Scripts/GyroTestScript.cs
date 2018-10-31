using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class GyroTestScript : MonoBehaviour {

    Gyroscope gyro;
    HeadBobber headBobScript;
    Animator anim;
    public GameObject walkingModel;
    public GameObject crouchingModel;

    // Use this for initialization
    void Start()
    {
        gyro = Input.gyro;
        gyro.enabled = true;
        headBobScript = Camera.main.GetComponent<HeadBobber>();
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", false);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
       //transform.Rotate(gyro.rotationRateUnbiased.x, gyro.rotationRateUnbiased.y, gyro.rotationRateUnbiased.z);       

        if ((Mathf.Round(gyro.gravity.y * 100)) / 100.0 == -1)
        {
            print("my dude");
            headBobScript.StopBobbing();
            anim.SetBool("Walking", false);
            walkingModel.SetActive(false);
            crouchingModel.SetActive(true);
        }
        else
        {
            transform.Translate(0, 0,  -transform.InverseTransformDirection(transform.forward).z * gyro.gravity.z / 25);
            transform.Rotate(0, Mathf.Ceil(gyro.gravity.x*100)/100, 0);
            headBobScript.StartBobbing();
            anim.SetBool("Walking", true);
            crouchingModel.SetActive(false);
            walkingModel.SetActive(true);
        }
        //print(gyro.rotationRate);
        //print(Mathf.Ceil(gyro.gravity.x * 100) / 100);
        //print(Mathf.Ceil(gyro.rotationRateUnbiased.z));
    }
}
