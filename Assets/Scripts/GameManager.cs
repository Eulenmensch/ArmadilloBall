using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Input,
    Execution
}
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public State currentState;

    private int currentTurn = 1;
    public int CurrentTurn => currentTurn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        currentState = State.Input;
    }

    public void ChangeToInputState()
    {
        currentState = State.Input;
        Player.Instance.ResetEnergyAmount();
        currentTurn++;
        print(currentTurn);
    }

    public void ChangeToExecutionState()
    {
        currentState = State.Execution;
    }
}
