using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private Queue<ICommand> commandsToExecute = new Queue<ICommand>();

    public void AddCommand(ICommand command)
    {
        commandsToExecute.Enqueue(command);
    }

    public IEnumerator ExectueAllCommands()
    {
        while (commandsToExecute.Count > 0)
        {
            yield return commandsToExecute.Dequeue().Execute();
        }
    }
}
