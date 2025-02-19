﻿using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game configuration data
    [SerializeField]
    [Multiline (10)]
    private string initialText;
    private const string menuHint = "You may type 'menu' at any time";
    private string[] level1Passwords = { "math", "english", "ruler", "books", "pencil" };
    private string[] level2Passwords = { "airplane", "hangar", "propeller", "luggage","runaway"};
    private string[] level3Passwords = { "astronaut", "telescope",
                                         "curiosity", "apollo" };

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

    
    void OnUserInput (string input)
    {

        if (input == "menu") // we can always go back to the main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
            MenuMessage();
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
            MenuMessage();
        }

    }

    private void MenuMessage()
    {
        Terminal.WriteLine(menuHint);
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level");
        }
    }

    

    void AskForPassword ()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/      
"               );
                break;
            case 2:
                Terminal.WriteLine("Take a flight...");
                Terminal.WriteLine(@"   
       __|__
--o--o--(_)--o--o--
"               );
                break;
            case 3:
                Terminal.WriteLine("You've gone to space...");
                  Terminal.WriteLine(@"   
.           .
       ___       .
  .   / O \    .
 .   .\___/   .    .
      /   \
");
                break;
            default:
                Debug.LogError("Invalid Level reached");
                break;
        }
    }
}
