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

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if(instance != this)
			Destroy (gameObject);
	}

	void Update()
	{
		Debug.Log (score);
		if (gameOver)
		{
			scoreText.text = "Score: " + score;	
			if (Input.GetKey ("up")) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
	}
}
