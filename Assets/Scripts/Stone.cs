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

	private Rigidbody rb;
	private CharacterController character;
	private LineRenderer lr;

	private bool isMoving = false;
	private bool startMoving = false;
	//private bool finishTurn = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () 
	{
		//check values and then calculate the speed/direction/rotation (and update UI)
		if (Input.GetKey ("up")) {
			Shoot();
		}

		if (isMoving) {
			float speed = rb.velocity.magnitude;
			if (speed == 0) {
				isMoving = false;
				Debug.Log ("hit up to play again!");
				GameController.instance.gameOver = true;
			}
		} else {
			CalculateSpeedAndDirection();
		}
		
	}

	void FixedUpdate() 
	{
		if (startMoving && !isMoving) {
			startMoving = false;
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

	void Shoot () 
	{
		if (!isMoving) {
			startMoving = true;
		}
	}
}
