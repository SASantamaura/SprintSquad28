using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobber : MonoBehaviour {

    public Vector3 restPosition;
    public Vector3 movingPosition;
    public float transitionSpeed = 20f;
    public float bobSpeed = 4.8f; 
    public float bobAmount = 0.05f; 

    float timer = Mathf.PI / 2;
    Vector3 camPos;

    bool footDown;
    void Awake()
    {
        camPos = transform.localPosition;
    }

    public void StartBobbing()
    {

        timer += bobSpeed * Time.deltaTime;
        Vector3 newPosition = new Vector3(Mathf.Cos(timer) * bobAmount, movingPosition.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)), movingPosition.z);
        transform.localPosition = newPosition;

        if(transform.localPosition.y <= 0.61f)
        {
            if(!footDown)
            {
                StartCoroutine("Footstep");
                footDown = true;
            }
        }

        if (timer > Mathf.PI * 2)
        {
            timer = 0;
        }
            
    }

    public void StopBobbing()
    {
        timer = Mathf.PI / 2;
        float lerpX = Mathf.Lerp(camPos.x, restPosition.x, transitionSpeed * Time.deltaTime);
        float lerpY = Mathf.Lerp(camPos.y, restPosition.y, transitionSpeed * Time.deltaTime);
        float lerpZ = Mathf.Lerp(camPos.z, restPosition.z, transitionSpeed * Time.deltaTime);
        Vector3 newPosition = new Vector3(lerpX, lerpY, lerpZ);
        transform.localPosition = newPosition;
    }

    IEnumerator Footstep()
    {
        this.transform.parent.GetComponent<PlayerSteps>().OnFootStep();
        yield return new WaitForSeconds(0.5f);
        footDown = false;
    }
}

