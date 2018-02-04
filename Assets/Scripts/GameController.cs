using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour 
{
	public int score = 0;         
	public int currentTurn = 1;
	public bool gameOver = false;    
	public int numberOfStones = 2;
	public float scrollSpeed = -1.5f;

	public Camera camera;
	public Text scoreText;
	public GameObject helpUi;
	public static GameController instance = null;

	void Awake() 
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update() 
	{
		if (currentTurn == 1) {
			if (Input.anyKey){
				HideInitUI();
			}
		}
		if (gameOver)
		{
			if (Input.GetKey ("up")) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}

	//when the stone has stopped, need to spawn an additional stone 
	//@todo - have to pass in turn number in a constructor
	public void SpawnNextStone(PlayerController player, Stone OGstone)
	{
		//copy a stone, set position, set parent, update to be the parent's current active stone, and reset the camera
		if (player.stoneCount < numberOfStones) {
			Stone newStone = Instantiate (OGstone, OGstone.origin, Quaternion.identity);
			newStone.turn++;
			newStone.player = player;
			newStone.transform.SetParent (player.transform);
			newStone.name = "Stone " + newStone.turn;
			player.addNewStone (newStone);
			ResetCamera (newStone);
		} else {
			Debug.Log ("You have used all your stones!");
			FinishGame ();
		}
	}

	public void ResetCamera(Stone newStone)
	{
		CameraController cam = camera.GetComponent<CameraController>();
		cam.ResetCamera (newStone.gameObject);
	}

	public void FinishGame()
	{
		//@todo do something interesting
		gameOver = true;
		Debug.Log("Press up to play again");
	}

	void HideInitUI()
	{
		helpUi.SetActive(false);
	}
}
