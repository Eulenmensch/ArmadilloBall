using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public CommandInvoker commandInvoker;

    public void OnMove(InputValue value)
    {
        Debug.Log("Here");
        commandInvoker.AddCommand(new MoveCommand(0.5f, value.Get<Vector2>()));
    }

    public void OnTestNiceMan()
    {
        StartCoroutine(commandInvoker.ExectueAllCommands());
    }
}
