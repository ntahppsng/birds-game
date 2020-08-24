﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the OnClick events for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Handles the on click event from the play button
    /// </summary>
    public void HandlePlay1ButtonOnClickEvent()
    {
        SceneManager.LoadScene("Game1");
    }

    /// <summary>
    /// Handles the on click event from the play button
    /// </summary>
    public void HandlePlay2ButtonOnClickEvent()
    {
        SceneManager.LoadScene("Game2");
    }

    /// <summary>
    /// Handles the on click event from the help button
    /// </summary>
    public void HandleHelpButtonOnClickEvent()
    {
        MenuManager.GoToMenu(MenuName.Help);
    }

    /// <summary>
    /// Handles the on click event from the quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }
} 
