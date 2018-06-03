using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlopSoundManager : MonoBehaviour {

    AudioSource blopsound;

	// Use this for initialization
	void Start () {
        blopsound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playBlobSound()
    {
        blopsound.Play();
    }
}
