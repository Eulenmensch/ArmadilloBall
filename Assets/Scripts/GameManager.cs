using FMOD.Studio;
using System;
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

    public SceneLoader sceneLoader;
    public static GameManager Instance => instance;

    public State currentState;

    private int currentTurn = 1;
    public int CurrentTurn => currentTurn;

    public event Action OnInputPhase;
    public event Action OnExecutionPhase;
    public event Action OnWin;

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
        sceneLoader.UI();
    }

    public void ChangeToInputState()
    {
        currentState = State.Input;
        Player.Instance.ResetEnergyAmount();
        Player.Instance.GetComponent<Animator>().SetBool("isIdle", true);
        Player.Instance.GetComponent<Animator>().SetBool("isMoving", false);
        OnInputPhase?.Invoke();

        currentTurn++;
    }

    public void ChangeToExecutionState()
    {
        currentState = State.Execution;
        Player.Instance.GetComponent<Animator>().SetBool("isIdle", false);
        Player.Instance.GetComponent<Animator>().SetBool("isMoving", true);
        OnExecutionPhase?.Invoke();
    }

    public void WinGame()
    {
        currentState = State.Win;
        Debug.Log("You won!");
        Player.Instance.rb.isKinematic = true;
        OnWin?.Invoke();
        StartCoroutine(LoadLevelInSeconds(5));
    }

    private IEnumerator LoadLevelInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        sceneLoader.LoadNextScene();
    }
}
