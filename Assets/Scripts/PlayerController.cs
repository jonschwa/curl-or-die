using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public int stoneCount;
	public int playerNumber;
	public int currentRoundScore;

	public Text scoreText;
	public Stone activeStone;


	void Awake() {
		stoneCount = 1;
	}

	public void NextTurn() {
		currentRoundScore = 0;
		Component[] stones = GetComponentsInChildren<Stone>();
		foreach (Stone stone in stones)
			currentRoundScore += stone.currentScore;

		UpdateScoreText();
		GameController.instance.SpawnNextStone (this, activeStone);
	}

	public void addNewStone(Stone newStone) 
	{
		activeStone = newStone;
		stoneCount++;
		Debug.Log ("# stones: " + stoneCount);
	}

	void UpdateScoreText() {
		scoreText.text = "Player " + playerNumber + " Score: " + currentRoundScore;	
	}


}
