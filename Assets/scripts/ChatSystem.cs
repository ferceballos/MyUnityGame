using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{

    public TextAsset script;
    // Use this for initialization
    void Start()
    {
        print(script.text);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void decompose()
    {
        string[] delimiter = { "\n" };
        string[] substrings = script.text.Split(delimiter, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (var substring in substrings)
            print(substring);
    }

    void nextLine()
    {

    }
}
