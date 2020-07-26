using FMOD.Studio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public enum State
{
    Input,
    Execution,
    Win,
    FlyThrough
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

    [SerializeField] private int turnsForBronze = 4;
    [SerializeField] private int turnsForSilver = 3;
    [SerializeField] private int turnsForGold = 2;

    [SerializeField] private PlayableAsset flyThroughAsset;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        sceneLoader.UI();
        SetStartState();
    }

    private void SetStartState()
    {
        if (flyThroughAsset)
        {
            currentState = State.FlyThrough;
            StartCoroutine(FreezeInputForSeconds((float)flyThroughAsset.duration));
        }
        else
        {
            Debug.LogWarning("Please assign a playable asset in the GameManager if you wish to perform a level-flythrough");
            currentState = State.Input;
        }
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
        Rating rating = CheckRating();
        int levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        GameState.Instance.SetLevelRating(levelNumber, rating);

        currentState = State.Win;
        Debug.Log("You won!");
        Player.Instance.rb.isKinematic = true;
        OnWin?.Invoke();
        StartCoroutine(LoadLevelInSeconds(5));   
    }

    public void QuitGame()
    {
        Debug.Log("Will quit in actual build");
        Application.Quit();
    }

    private Rating CheckRating()
    {
        if(currentTurn <= turnsForGold)
        {
            return Rating.Gold;
        }
        else if (currentTurn <= turnsForSilver)
        {
            return Rating.Silver;
        }
        else if(currentTurn <= turnsForBronze)
        {
            return Rating.Bronze;
        }
        else
        {
            return Rating.Unfinished;
        }
    }

    private IEnumerator FreezeInputForSeconds(float seconds)
    {
        print(currentState);
        yield return new WaitForSeconds(seconds);
        currentState = State.Input;
        print(currentState);
    }

    private IEnumerator LoadLevelInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        sceneLoader.LoadNextScene();
    }
}
