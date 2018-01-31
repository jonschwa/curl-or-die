using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour {

	public string playerTag = "Player";

	public int pointValue;

	void OnTriggerEnter(Collider other) {
		if (other.tag == playerTag) {
			Debug.Log ("entered " + pointValue);
			GameController.instance.score += pointValue;
		}
	}

	void OnTriggerExit(Collider other) {
		Debug.Log ("Exited " + pointValue);
		GameController.instance.score -= pointValue;
	}

	void OnTriggerStay(Collider other) {
		//@todo - can I use this to detect "fully inside" trigger?
	}
}
