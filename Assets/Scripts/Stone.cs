using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Stone : MonoBehaviour 
{
	public int turn = 1;
	public float moveTime; 
	public float moveSpeed;
	private float xDir;
	public int currentScore;
	public Vector3 moveDirection = new Vector3(0f, 0f, 1f);

	public Vector3 origin;
	public Slider powerSlider;
	public PlayerController player;
	public bool active = true;

	private Rigidbody rb;


	public bool isMoving = false;
	private bool shot = false;
	private float speed;
	private bool finishTurn = false;

	void Awake () 
	{
		currentScore = 0;
		xDir = 0f;
		origin = transform.position;
		rb = GetComponent<Rigidbody>();
		player = GetComponentInParent<PlayerController>();
	}

	void Update () 
	{
		//await input before the stone is shot
		if (!shot) {
			if (Input.GetKey("q")) {
				Shoot ();
			}
		}
			
		// if the stone is no longer active, we still need to update the score if it changes
		speed = rb.velocity.magnitude;
		if (!active) {
			if (speed != 0) {
				Debug.Log ("Stone " + turn + " Moving!");
				isMoving = true;
			}
		}

		//after the stone has been shot, keep track of the score if its moving
		if (shot && isMoving) {
			if (speed == 0) {
				isMoving = false;
				finishTurn = true;
				Debug.Log ("Turn " + turn + " Over. Score: " + currentScore);
				player.UpdateTurnScore();
			}
		} 
		//or check the inputs for the speed and direction modifiers
		else {
			CalculateSpeedAndDirection();
		}
		
	}

	void FixedUpdate() 
	{
		//give the initial shot of force when the stone is launched
		if (shot && !isMoving && !finishTurn) {
			Debug.Log ("starting to move!");
			Debug.Log (moveDirection);
			rb.AddForce (moveDirection * moveSpeed, ForceMode.Impulse);
			isMoving = true;
		}
	}

	void CalculateSpeedAndDirection () 
	{
		//horizontal currently on the arrows @todo - make a UI element
		float h = Input.GetAxisRaw("Horizontal");
		moveSpeed = powerSlider.value;

		if (Mathf.Abs (h) >= 1) {
			xDir += h * 0.01f;
		}
		//the z component of movement is always ahead currently 
		//@todo - might want to make this just oriented towards the target
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
