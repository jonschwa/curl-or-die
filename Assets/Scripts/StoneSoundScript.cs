using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoneSoundScript : MonoBehaviour

{
	AudioSource audio;
	Stone stone;

	void Awake()
	{
		stone = GetComponent<Stone>();
		audio = GetComponent<AudioSource>();	}

	void Update ()
	{
		//only play if stone is moving and audio is not currently playing
		if (stone.isMoving) {
			if(!audio.isPlaying)
				audio.Play ();
		}
		else {
			if(audio.isPlaying)
				audio.Stop();
		}
	}

}