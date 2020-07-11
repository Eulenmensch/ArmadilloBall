using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Input,
    Execution,
    Win
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
    }

    public void ChangeToExecutionState()
    {
        currentState = State.Execution;
    }

    public void WinGame()
    {
        currentState = State.Win;
        Debug.Log("You won!");
        StopAllCoroutines();
    }
}
