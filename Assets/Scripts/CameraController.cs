using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	public bool reset = false;

	public Vector3 origin;
	private Vector3 offset;
	public GameObject stoneToFollow;

	void Awake () 
	{
		origin = transform.position;
		Debug.Log ("camera origin " + origin);
		offset = transform.position - stoneToFollow.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = stoneToFollow.transform.position + offset;
	}

	public void ResetCamera(GameObject stone)
	{
		Debug.Log ("resetting camera to " + origin);
		transform.position = origin;
		stoneToFollow = stone;
	}	
}
