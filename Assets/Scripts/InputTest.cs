using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public CommandInvoker commandInvoker;
    public EnergyController energyController;
    public FloatVariable energy;

    private float timePressed;
    private Vector2 direction;


    public void OnMove(InputValue value)
    {
        if (energy.value <= 0) return;

        if(timePressed == 0)
        {
            direction = value.Get<Vector2>();
            timePressed = Time.time;
            energyController.StartEnergyDrain();
        }
        else
        {
            energyController.StopEnergyDrain();
            SendMoveCommand();
        }
        
    }

    public void OnTestNiceMan()
    {
        StartCoroutine(commandInvoker.ExectueAllCommands());
    }

    private void Update()
    {
        
    }

    public void SendMoveCommand()
    {
        float pressDuration = Time.time - timePressed;
        commandInvoker.AddCommand(new MoveCommand(pressDuration, direction));
        timePressed = 0f;
    }
}
