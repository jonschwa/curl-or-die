using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StoneSoundScript : MonoBehaviour

{
	AudioSource StoneAudioSource;
	Stone stone;

	void Awake()
	{
		stone = GetComponent<Stone>();
	}

	void Update ()
	{
		if (stone.isMoving) {
			StoneAudioSource.Play ();
		}
		else {
			StoneAudioSource.Stop();
		}
	}

}