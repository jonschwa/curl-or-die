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

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		collider = GetComponent<BoxCollider>();
		character = GetComponent<CharacterController>();
	}

	void CalculateSpeedAndDirection () {
		//static for now
		//moveSpeed = 200.0f;

		//setting this to straight up right now for simplicity
		moveDirection = new Vector3(0, 0, 1);
	}
		
	//to update the visual indicator of the power selected
	void DisplayPower(int amount) {

	}

	void Shoot (Vector3 direction, int speed) {

	}

	void CheckIfEndOfMove() {

	}

	void FinishTurn() {

	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			CalculateSpeedAndDirection ();
			//moveDirection = transform.TransformDirection (moveDirection);
			startMoving = true;
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
