using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private CommandInvoker commandInvoker = null;
    [SerializeField] private EnergyController energyController = null;
    [SerializeField] private FloatVariable energy = null;

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

    public void OnCurl()
    {
        if (energy.value < energyController.EnergyCostCurleToggle) return;

        energy.value -= energyController.EnergyCostCurleToggle;
        commandInvoker.AddCommand(new CurlCommand());
    }

    public void OnSubmitMovement()
    {
        StartCoroutine(commandInvoker.ExectueAllCommands());
    }

    public void SendMoveCommand()
    {
        float pressDuration = Time.time - timePressed;
        commandInvoker.AddCommand(new MoveCommand(pressDuration, direction));
        timePressed = 0f;
    }
}
