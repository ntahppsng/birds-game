using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	#region Fields

	// score support
	Text scoreText;
	[SerializeField]
	int score = 10;
	const string ScorePrefix = "Score: ";

	// Timer support
	[SerializeField]
	int secondsForGame = 10;
	[SerializeField]
	int bonusTime = 5;
	Timer gameTimer;
	Text timeText;
	const string TimePrefix = "Time left: ";

	//Game End support
	GameEnded gameEnded;
	bool gameEndedB = false;
	#endregion

	// Use this for initialization
	void Start() {
		// Create and start timer
		gameTimer = gameObject.AddComponent<Timer>();
		gameTimer.Duration = secondsForGame;
		gameTimer.Run();

		// Initialize timer text
		timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>();
		timeText.text = TimePrefix + secondsForGame;

		// Initialize score text
		scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
		scoreText.text = ScorePrefix + score;


		gameEnded = new GameEnded();
		EventManager.AddGameEndedInvoker(this);

		// Add listeners to the event manager
		EventManager.AddPointsChangedListener(ChangePoints);
		EventManager.AddBonusBarCompletedListener(ChangeTime);

	}

	// Update is called once per frame
	void Update() {
		if (gameTimer.Running)
		{
			timeText.text = TimePrefix + (int)gameTimer.SecondsLeft;
		}
		if (!gameEndedB && (gameTimer.Finished || score <= 0))
        {
			gameEnded.Invoke((int) gameTimer.Duration, score);
			gameEndedB = true;
        }
	}

	public void AddGameEndedListener(UnityAction<int,int> listener)
    {
		gameEnded.AddListener(listener); 
    }

    #region Private methods

	void ChangePoints(int points)
    {
		score += points;
		scoreText.text = ScorePrefix + score;
    }
	void ChangeTime()
	{
		gameTimer.AddTime(bonusTime);
		timeText.text = TimePrefix + (int) gameTimer.SecondsLeft;
	}
	#endregion
}
