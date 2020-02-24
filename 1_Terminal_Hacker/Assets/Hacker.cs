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
        Terminal.WriteLine(initialText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
