using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public int currentRoundScore = 0;
	public int currentTurnScore = 0;
	public Text scoreText;
	public int playerNumber;


	void Awake() {
		
	}

	public void CalculateRoundScore()
	{
		//round score can be calculated by adding the scores of all the child stones
		UpdateScoreText(currentRoundScore);
	}

	public void UpdateTurnScore(int scoreChange) {
		currentTurnScore += scoreChange;
		UpdateScoreText(currentTurnScore);
	}

	void UpdateScoreText(int score) {
		scoreText.text = "Player " + playerNumber + " Score: " + score;	
	}
		

}
