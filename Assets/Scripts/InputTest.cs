using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public CommandInvoker commandInvoker;

    private float timePressed;
    private Vector2 direction;

    public void OnMove(InputValue value)
    {
        if(timePressed == 0)
        {
            direction = value.Get<Vector2>();
            timePressed = Time.time;
        }
        else
        {
            float pressDuration = Time.time - timePressed;
            commandInvoker.AddCommand(new MoveCommand(pressDuration, direction));
            timePressed = 0f;
        }
        
    }

    public void OnTestNiceMan()
    {
        StartCoroutine(commandInvoker.ExectueAllCommands());
    }

    private void Update()
    {
        
    }
}
