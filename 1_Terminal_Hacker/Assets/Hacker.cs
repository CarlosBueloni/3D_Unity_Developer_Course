using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private const string MI_EASTEREGG = "Your mission ______, should you choose to accept it, is to select a level.";
    [SerializeField]
    [Multiline(10)]
    private string initialText;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(initialText);
    }

    void OnUserInput(string input)
    {
       if(input == "menu")
        {
            ShowMainMenu();
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
}
