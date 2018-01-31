using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour {

	public string playerTag = "Player";

	public int pointValue;

	int ReturnScore()
	{
		return pointValue;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == playerTag) {
			Debug.Log (ReturnScore () + " Points!");

		}
	}

	void OnTriggerStay(Collider other) {
		Debug.Log ("Staying in " + ReturnScore ());
	}
}
