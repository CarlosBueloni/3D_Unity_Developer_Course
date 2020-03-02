using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    private const string MI_EASTEREGG = "Your mission, should you choose to accept it, is to select a level.";

    enum Screen {
        MainMenu,
        Password,
        Win
    }

    //Cached Variables
    [SerializeField]
    [Multiline (10)]
    private string initialText;

    //Game State
    int level;
    Screen currentScreen;

    // Start is called before the first frame update
    void Start () {
        ShowMainMenu ();
    }

    public void ShowMainMenu () {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen ();
        Terminal.WriteLine (initialText);

    }

    
    void OnUserInput (string input) {

        if (input == "menu") // we can always go back to the main menu
        {
            ShowMainMenu ();
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }

    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "MI")
        {
            Terminal.WriteLine(MI_EASTEREGG);
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level");
        }
    }

    void StartGame () {
        currentScreen = Screen.Password;
        Terminal.WriteLine ("You chose level " + level);
        Terminal.WriteLine ("Please type your password: ");
    }
}
