using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private CommandInvoker commandInvoker = null;
    [SerializeField] private EnergyController energyController = null;
    [SerializeField] private FloatVariable energy = null;
    [SerializeField] private GameObject arrowPrefab = null;

    private float timePressed;
    private Vector2 direction;
    private GameObject arrow;
    private MoveArrow arrowController;


    // public void OnMove(InputValue value)
    // {
    //     if (energy.value <= 0) return;
    //     if (timePressed == 0)
    //     {
    //         direction = value.Get<Vector2>();
    //         timePressed = Time.time;
    //         energyController.StartEnergyDrain();
    //     }
    //     else
    //     {
    //         energyController.StopEnergyDrain();
    //         SendMoveCommand();
    //     }
    // }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (energy.value <= 0) return;
        if (context.started)
        {
            timePressed = Time.time;
            energyController.StartEnergyDrain();
            ShowMoveArrow();
        }
        if (context.performed)
        {
            direction = context.ReadValue<Vector2>();
            if (direction == Vector2.zero)
            {
                print("input is zero");
            }
            MoveAndScaleMoveArrow();
        }
        if (context.canceled)
        {
            energyController.StopEnergyDrain();
            SendMoveCommand();
            HideMoveArrow();
        }
    }

    public void OnCurl(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            if (energy.value < energyController.EnergyCostCurleToggle) return;

            energy.value -= energyController.EnergyCostCurleToggle;
            commandInvoker.AddCommand(new CurlCommand());
        }
    }

    public void OnSubmitMovement(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            StartCoroutine(commandInvoker.ExectueAllCommands());
        }
    }

    public void SendMoveCommand()
    {
        float pressDuration = Time.time - timePressed;
        commandInvoker.AddCommand(new MoveCommand(pressDuration, direction));
        timePressed = 0f;
    }

    private void ShowMoveArrow()
    {
        arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrowController = arrow.GetComponent<MoveArrow>();
    }

    private void MoveAndScaleMoveArrow()
    {
        Vector3 arrowDirection = new Vector3(direction.x, 0, direction.y);
        arrowController.SetArrowDirection(arrowDirection);
        arrowController.SetArrowLength(Time.time - timePressed);
    }

    private void HideMoveArrow()
    {
        Destroy(arrow);
    }
}
