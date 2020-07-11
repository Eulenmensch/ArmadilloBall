using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public CommandInvoker commandInvoker;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            commandInvoker.AddCommand(new MoveCommand(1, new Vector2(1, 1)));
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(commandInvoker.ExectueAllCommands());
        }
    }
}
