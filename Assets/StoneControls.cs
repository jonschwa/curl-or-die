using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneControls : MonoBehaviour {

	public int powerSliderMoveDir;
	public Slider powerSlider;
	//public Button shootButton;

	private float xDir;
	//private bool powerSelected;

	private Stone stone;

	void Awake () {
		stone = GetComponent<Stone>();
		//powerSelected = false;
		ResetUI();
	}
	
	// Update is called once per frame
	void Update () {
		if (!stone.shot) {
			CalculateSpeedAndDirection();
			if (Input.GetKey("q")) {
				stone.Shoot ();
			}

			if (Input.GetKey("w")) {
				//stone.Shoot ();
				if (powerSlider.value == powerSlider.minValue) {
					//start iterating upward
					powerSliderMoveDir = 1;
				} else if (powerSlider.value == powerSlider.maxValue) {
					//start iterating backwards
					powerSliderMoveDir = -1;
				}

				powerSlider.value += (0.75f * powerSliderMoveDir);
			}

			if (Input.GetKeyUp("w")) {
				CalculateSpeedAndDirection();
				stone.Shoot();
			}
		}
	}
		
	void CalculateSpeedAndDirection () 
	{
		//horizontal currently on the arrows @todo - make a UI element
		float h = Input.GetAxisRaw("Horizontal");
		stone.moveSpeed = powerSlider.value;

		if (Mathf.Abs (h) >= 1) {
			xDir += h * 0.01f;
		}
		//the z component of movement is always ahead currently 
		//@todo - might want to make this just oriented towards the target
		stone.moveDirection = new Vector3 (xDir, 0f, 1f);
	}

	void ResetUI()
	{
		//reset the UI controls
		powerSlider.value = 0;
	}

	void PickPower()
	{

	}

}
