using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Input,
    Execution
}
public class GameStateManager : MonoBehaviour
{
    public static State currentState;

    private void Awake()
    {
        currentState = State.Input;
    }

    public static void ChangeToInputState()
    {
        currentState = State.Input;
        Player.Instance.ResetEnergyAmount();
    }

    public static void ChangeToExecutionState()
    {
        currentState = State.Execution;
    }
}
