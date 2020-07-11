using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    public static Queue<ICommand> commandsToExecute = new Queue<ICommand>();

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
