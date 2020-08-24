using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSI : MonoBehaviour {

	// Use this for initialization
	void Start () {

		EventManager.AddGameEndedListener(EndGame);
		
	}

    void EndGame(int elapsedTime, int earnedPoints)
	{
		GameObject hud = GameObject.FindGameObjectWithTag("HUD");
		hud.SetActive(false);
		// instantiate prefab and set score
		GameObject gameOverMenu = Instantiate(Resources.Load("GameOver")) as GameObject;
		GameOverMenu gameOverMenuScript = gameOverMenu.GetComponent<GameOverMenu>();
		gameOverMenuScript.SetFinalScore(elapsedTime, earnedPoints);
    }

    // Update is called once per frame
    void Update () {
		// pause game on escape key
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuManager.GoToMenu(MenuName.Pause);
		}
	}
}
