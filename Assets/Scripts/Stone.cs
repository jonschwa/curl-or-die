using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Stone : MonoBehaviour 
{
	public int turn = 1;
	public float moveSpeed;
	public int currentScore;
	public bool shot;
	public bool isMoving;
	public Vector3 moveDirection;

	public Vector3 origin;
	public PlayerController player;
	public bool active;

	private Rigidbody rb;

	private float speed;

	void Start () 
	{
		active = true;
		currentScore = 0;
		origin = transform.position;
		rb = GetComponent<Rigidbody>();
		player = GetComponentInParent<PlayerController>();
		shot = false;
		isMoving = false;
	}

	void Update () 
	{
		// we will want the speed every frame
		// pro tip - if you do this in fixedUpdate, you're going to have a bad time!
		speed = rb.velocity.magnitude;

		//after the stone has been shot, keep track of the score if its moving
		if (shot && isMoving) {
			if (speed == 0) {
				isMoving = false;
				active = false;
				Debug.Log ("Turn " + turn + " Over. Score: " + currentScore);
				player.NextTurn();
			}
		} 

		// if the stone is no longer active, we still need to update the score if it changes
		// todo - I think this will not be needed if we can be sure the stone isn't moving (falling) on awake
		if (!active) {
			if (speed != 0) {
				Debug.Log ("Stone " + turn + " Moving!");
				isMoving = true;
			}
		}
		
	}

	void FixedUpdate() 
	{
		//give the initial shot of force when the stone is launched
		if (shot && !isMoving && active) {
			rb.AddForce (moveDirection * moveSpeed, ForceMode.Impulse);
			isMoving = true;
		}
	}
		
	public void UpdateScore(int scoreChange)
	{
		currentScore += scoreChange;
	}

	public void Shoot () 
	{
		if (!shot) {
			Debug.Log ("Speed " + moveSpeed);
			shot = true;
		}
	}

}
