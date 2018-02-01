using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Stone : MonoBehaviour {

	public float moveSpeed;
	//set this to straight up initially
	public Vector3 moveDirection = new Vector3(0f, 0f, 1f);
	public float moveTime; 
	private float xDir = 0f;
	public Slider powerSlider;
	public int turn = 1;

	private Rigidbody rb;
	private PlayerController player;

	private int currentScore = 0;
	private bool isMoving = false;
	private bool shot = false;
	private float speed;
	private bool finishTurn = false;

	void Awake () 
	{
		rb = GetComponent<Rigidbody>();
		player = GetComponentInParent<PlayerController>();
	}

	void Update () 
	{
		//check values and then calculate the speed/direction/rotation (and update UI)
		if (!shot) {
			if (Input.GetKey("q")) {
				Shoot ();
			}
		}

		//@todo - this will be used for collisions (score will change)
//		speed = rb.velocity.magnitude;
//		if (speed != 0) {
//			Debug.Log("Stone " + turn + " Moving!");
//			isMoving = true;
//		}

		if (shot && isMoving) {
			speed = rb.velocity.magnitude;
			if (speed == 0) {
				isMoving = false;
				finishTurn = true;
				Debug.Log ("Turn " + turn + " Over. Score: " + currentScore);
				player.UpdateTurnScore(currentScore);
			}
		} else {
			CalculateSpeedAndDirection();
		}
		
	}

	void FixedUpdate() 
	{
		if (shot && !isMoving && !finishTurn) {
			//startMoving = false;
			Debug.Log ("starting to move!");
			Debug.Log (moveDirection);
			rb.AddForce (moveDirection * moveSpeed, ForceMode.Impulse);
			isMoving = true;
		}
	}

	void CalculateSpeedAndDirection () 
	{
		float h = Input.GetAxisRaw("Horizontal");
		moveSpeed = powerSlider.value;

		if (Mathf.Abs (h) >= 1) {
			xDir += h * 0.01f;
		}
		moveDirection = new Vector3 (xDir, 0f, 1f);
	}

	public void UpdateScore(int scoreChange)
	{
		currentScore += scoreChange;
	}

	void Shoot () 
	{
		if (!shot) {
			Debug.Log ("Shooting!");
			shot = true;
		}
	}
}
