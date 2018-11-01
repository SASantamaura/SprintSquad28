using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;

    float bobbing;
    bool leaningLeft;
    bool leaningRight;
    bool detectable;
    Rigidbody rb;
    Camera cam;
    Quaternion leftLean;
    Quaternion rightLean;
    HeadBobber headBob;

    

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        bobbing = 0;
        leaningRight = true;
        leaningLeft = false;
        headBob = Camera.main.GetComponent<HeadBobber>();
        
    }

<<<<<<< HEAD
    
=======
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pickup")
        {
            pickupScore++;
            Destroy(other.gameObject);
        }

        if(other.gameObject.name == "Zone")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
>>>>>>> 1d8dc6e406cf553443415433396ab747e055b3af

 
         
    
    




    // Update is called once per frame
    void Update ()
    {

        if (Input.GetKeyUp("space"))
        {
            Debug.Log("Standing up");
            transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
            detectable = true;
        }

        if (!Input.GetKey("space"))
        {
            //float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
            float y = Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed;

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.Rotate(0, y, 0);
            headBob.StartBobbing();

        }
        else
        {
            detectable = false;
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            headBob.StopBobbing();
        }


	}
}
