using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game configuration data
    [SerializeField]
    [Multiline (10)]
    private string initialText;
    private string[] level1Passwords = { "math", "english", "ruler", "books", "pencil" };
    private string[] level2Passwords = { "aircratf", "hangar", "propeller", "luggage","runaway"};

    //Game State
    private enum Screen
    {   MainMenu,
        Password,
        Win
    }
    private int level;
    private Screen currentScreen;
    private string password;


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
        } else if (currentScreen == Screen.MainMenu) 
        {
            RunMainMenu(input);

        } else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }



    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = level1Passwords[2]; // todo make random later
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Passwords[4]; // todo make random later
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level");
        }
    }

    void StartGame () {
        currentScreen = Screen.Password;
        Terminal.WriteLine ("You chose level " + level+ ".");
        Terminal.WriteLine("");
        Terminal.WriteLine ("Please type your password: ");
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            RunWinScreen();
        }
        else
        {
            Terminal.WriteLine("Please try again.");
        }
    }

    private void RunWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.WriteLine("Congratulations! You hacked level " + level);
    }
}
