using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private static CommandInvoker instance;
    public static CommandInvoker Instance => instance;
    public Queue<ICommand> commandsToExecute = new Queue<ICommand>();

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
    }

    public void AddCommand(ICommand command)
    {
        commandsToExecute.Enqueue(command);
    }

    public IEnumerator ExectueAllCommands()
    {
        GameManager.Instance.ChangeToExecutionState();

        while (commandsToExecute.Count > 0)
        {
            yield return commandsToExecute.Dequeue().Execute();
        }

        GameManager.Instance.ChangeToInputState();
    }
}
