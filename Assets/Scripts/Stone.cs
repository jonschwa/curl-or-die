using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	public float moveSpeed;
	public Vector3 moveDirection;
	public float moveTime; 
	public float gravity = 20.0F;

	private Rigidbody rb;
	private BoxCollider collider;
	private CharacterController character;
	private bool isMoving = false;
	private bool endOfMove = false;
	private bool startMoving = false;
	private bool finishTurn = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		collider = GetComponent<BoxCollider>();
		//character = GetComponent<CharacterController>();
	}

	void CalculateSpeedAndDirection () {
		//
		moveDirection = new Vector3(0, 0, 1);
	}
		
	//to update the visual indicator of the power selected
	void DisplayPower(int amount) {

	}

	void Shoot () {
		if (!isMoving) {
			CalculateSpeedAndDirection();
			//moveDirection = transform.TransformDirection (moveDirection);
			startMoving = true;
		}
	}

	void CheckIfEndOfMove() {

	}

	void FinishTurn() {

	}

	// Update is called once per frame
	void Update () {
		//check values and then calculate the speed/direction/rotation (and update UI)
		if (Input.GetKey ("up")) {
			print ("shooting!");
			Shoot();
		}
		if (isMoving) {
			float speed = rb.velocity.magnitude;
			if (speed == 0) {
				finishTurn = true;
			}
		}
		
	}

	void FixedUpdate() {
		if (startMoving && !isMoving) {
			Debug.Log ("starting to move!");
			rb.AddForce (moveDirection * moveSpeed, ForceMode.Impulse);
			isMoving = true;
		}
	}
}
