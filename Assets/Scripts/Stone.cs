using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	public float speed = 15.0F;
	public Vector3 moveDirection;
	public float gravity = 20.0F;

	private Rigidbody rb;
	private SphereCollider collider;
	private CharacterController character;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		collider = GetComponent<SphereCollider>();
		character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;

		//moveDirection.y -= gravity * Time.deltaTime;
		character.Move(moveDirection * Time.deltaTime);
	}
}
