using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource blop_sound;
    AudioSource success_sound;
    AudioSource failure_sound;
    AudioSource bonus_sound;

    // Use this for initialization
    void Start () {
        blop_sound = GetComponents<AudioSource>()[0];
        failure_sound = GetComponents<AudioSource>()[1];
        success_sound = GetComponents<AudioSource>()[2];
        bonus_sound = GetComponents<AudioSource>()[3];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playBlobSound()
    {
        blop_sound.Play();
    }
    public void playSuccessSound()
    {
        success_sound.Play();
    }
    public void playFailureSound()
    {
        failure_sound.Play();
    }
    public void playBonusSound()
    {
        bonus_sound.Play();
    }
}
