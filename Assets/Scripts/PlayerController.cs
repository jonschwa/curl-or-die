using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	public int stoneCount;
	public int playerNumber;
	public int currentTurnScore = 0;
	public int currentRoundScore = 0;

	public Text scoreText;
	public Stone activeStone;


	void Awake() {
		stoneCount = 1;
	}
		
	public void UpdateTurnScore(int scoreChange) {
		currentTurnScore += scoreChange;
		UpdateScoreText(currentTurnScore);
		GameController.instance.SpawnNextStone (this, activeStone);
	}

	public void addNewStone(Stone newStone) 
	{
		activeStone = newStone;
		stoneCount++;
		Debug.Log ("# stones: " + stoneCount);
	}

	void UpdateScoreText(int score) {
		scoreText.text = "Player " + playerNumber + " Score: " + score;	
	}


}
