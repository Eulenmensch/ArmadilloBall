using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private EnergyController energyController = null;
    [SerializeField] private FloatVariable energy = null;
    [SerializeField] private GameObject arrowPrefab = null;

    private float timePressed;
    private Vector2 direction;
    private GameObject arrow;
    private MoveArrow arrowController;

    private bool isReady = false;

    private void Update()
    {
        if (energy.value > 0.0f && direction.magnitude > 0.0f && isReady)
        {
            MoveAndScaleMoveArrow();
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.currentState != State.Input) return;

        if (energy.value <= 0)
        {
            Destroy(arrow);
            return;
        }

        Debug.Log(isReady);

        if (context.started)
        {
            timePressed = Time.time;
            energyController.StartEnergyDrain();
            ShowMoveArrow();
            isReady = true;
        }

        if (!isReady) return;

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

        if(context.canceled)
        {
            if (arrow != null)
            {
                energyController.StopEnergyDrain();
                SendMoveCommand();
                HideMoveArrow();
                direction = Vector2.zero; 
            }

            isReady = false;
        }
    }

    public void OnCurl(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.currentState != State.Input) return;

        if (context.canceled)
        {
            if (energy.value < energyController.EnergyCostCurleToggle) return;
            
            energy.value -= energyController.EnergyCostCurleToggle;
            CommandInvoker.Instance.AddCommand(new CurlCommand());
        }
    }

    public void OnSubmitMovement(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.currentState != State.Input) return;
        if (isReady) return;

        if (context.started)
        {
            StartCoroutine(CommandInvoker.Instance.ExectueAllCommands());
        }
    }

    public void SendMoveCommand()
    {
        float pressDuration = Time.time - timePressed;
        CommandInvoker.Instance.AddCommand(new MoveCommand(pressDuration, direction));
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