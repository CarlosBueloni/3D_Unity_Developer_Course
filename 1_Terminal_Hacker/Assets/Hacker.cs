using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private const string MI_EASTEREGG = "Your mission, should you choose to accept it, is to select a level.";
    
    enum Screen
    {
        MainMenu,
        Password,
        Win
    };

    //Cached Variables
    [SerializeField]
    [Multiline(10)]
    private string initialText;


    //Game State
    int level;
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(initialText);
        currentScreen = Screen.MainMenu;

    }

    void OnUserInput(string input)
    {
       if(input == "menu")
        {
            ShowMainMenu();
        }
        else if(input == "1")
        {
            level = 1;
            StartGame();
        }
        else if(input == "2")
        {
            level = 2;
            StartGame();
        }
        else if(input == "3")
        {
            level = 3;
            StartGame();
        }
        else if(input == "MI")
        {
            Terminal.WriteLine(MI_EASTEREGG);
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        Terminal.WriteLine("You chose level " + level);
        Terminal.WriteLine("Please type your password: ");
        currentScreen = Screen.Password;
    }
}
