using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour {

	public string playerTag = "Player";

	public int pointValue;

	void OnTriggerEnter(Collider other) {
		if (other.tag == playerTag) {
			Debug.Log (pointValue + " Points!");

		}
	}

	void OnTriggerStay(Collider other) {
		Debug.Log ("Staying in " + pointValue);
	}
}
