﻿using System.Collections;
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

    private void Update()
    {
        if (energy.value > 0.0f && direction.magnitude > 0.0f)
        {
            MoveAndScaleMoveArrow();
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (energy.value <= 0)
        {
            Destroy(arrow);
            return;
        }
        if (context.performed)
        {
            var inputDirection = context.ReadValue<Vector2>();
            if (inputDirection.magnitude > 0.5f)
            {
                if (arrow == null)
                {
                    timePressed = Time.time;
                    energyController.StartEnergyDrain();
                    ShowMoveArrow();
                }
                direction = context.ReadValue<Vector2>();
            }
            else
            {
                if (arrow != null)
                {
                    energyController.StopEnergyDrain();
                    SendMoveCommand();
                    HideMoveArrow();
                    direction = Vector2.zero;
                }
            }
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
        if (context.started)
        {
            StartCoroutine(commandInvoker.ExectueAllCommands());
        }
    }

    public void SendMoveCommand()
    {
        print(direction);
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
