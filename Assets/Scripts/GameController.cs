using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameController : MonoBehaviour {

	public static GameController instance = null;

	private int score = 0;                     
	public bool gameOver = false;             
	public float scrollSpeed = -1.5f;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update()
	{
		
		//If the game is over and the player has pressed some input...
		if (gameOver)
		{
			if (Input.GetKey ("up")) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}

}
