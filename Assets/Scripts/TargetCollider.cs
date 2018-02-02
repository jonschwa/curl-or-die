using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
	public int pointValue;
	public string stoneTag = "Stone";

	//update the score on the stone object any time it changes (enter/exit)
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == stoneTag) {
			Stone stone = other.transform.gameObject.GetComponent<Stone>();
			Debug.Log ("Adding " + pointValue + " from " + stone.name + "'s score");
			stone.UpdateScore(pointValue);
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.tag == stoneTag) {
			Stone stone = other.transform.gameObject.GetComponent<Stone>();
			Debug.Log ("Subtracting " + pointValue + " from " + stone.name + "'s score");
			stone.UpdateScore(-pointValue);
		}
	}

	void OnTriggerStay(Collider other) {
		//@todo - can I use this to detect "fully inside" trigger?
	}
}
