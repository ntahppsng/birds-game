using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

    [SerializeField]
    Text messageText;

    // Use this for initialization
    void Start ()
    {
        // pause the game when added to the scene
        Time.timeScale = 0;


    }
	

    /// <summary>
    /// Handles the on click event from the play button
    /// </summary>
    public void HandleRestartButtonOnClickEvent()
    {
        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    /// <summary>
    /// Handles the on click event from the help button
    /// </summary>
    public void HandleMainMenuButtonOnClickEvent()
    {
        // unpause game, destroy menu, and go to main menu
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
    }

    /// <summary>
    /// Handles the on click event from the quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        Destroy(gameObject);
        Application.Quit();
    }

    public void SetFinalScore(int elapsedTime, int earnedPoints)
    {
        messageText.text = "Your final result: " + elapsedTime + "s, " + earnedPoints + " points.";
    }
}
