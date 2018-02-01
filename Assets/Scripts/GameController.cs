using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public static GameController instance = null;

	public int score = 0;                     
	public bool gameOver = false;             
	public float scrollSpeed = -1.5f;
	public Text scoreText;
	public int numberOfStones = 3;
	public int currentTurn = 1;

	void Awake() 
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update() 
	{
		//Debug.Log (score);
		if (gameOver)
		{
			//scoreText.text = "Score: " + score;	
			if (Input.GetKey ("up")) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}

	//when the stone has stopped, need to spawn an additional stone 
	//@todo - have to pass in turn number in a constructor
	public void SpawnNextStone(GameObject parent)
	{
		//
	}
}
