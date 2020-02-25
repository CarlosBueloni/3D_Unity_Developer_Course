using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    
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
        print(input);
    }
}
