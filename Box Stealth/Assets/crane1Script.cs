using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crane1Script : MonoBehaviour {

    public GameObject spotlight;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, spotlight.transform.position.z);
    }
}
