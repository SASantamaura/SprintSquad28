using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour {

    AudioSource feet;
    public AudioClip step1;
    public AudioClip step2;
    public AudioClip step3;

	// Use this for initialization
	void Start ()
    {
        feet = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	public void OnFootStep ()
    {
        int currentSound = Random.Range(1, 4);

        switch(currentSound)
        {
            case 1:
                feet.PlayOneShot(step1);
                break;
            case 2:
                feet.PlayOneShot(step2);
                break;
            case 3:
                feet.PlayOneShot(step3);
                break;
            default:
                feet.PlayOneShot(step3);
                break;
        }
    }
}
