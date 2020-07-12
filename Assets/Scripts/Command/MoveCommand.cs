using System;
using System.Collections;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Vector2 moveDirection;
    private float moveDuration;
    [SerializeField] private float stopAcceleration;


    public MoveCommand(float moveDuration, Vector2 moveDirection)
    {
        this.moveDirection = moveDirection;
        this.moveDuration = moveDuration;
    }

    public IEnumerator Execute()
    {
        return MovePlayerInDirection(moveDuration, moveDirection);
    }

    private IEnumerator MovePlayerInDirection(float moveDuration, Vector2 moveDirection)
    {
        var rb = Player.Instance.rb;
        rb.isKinematic = false;

        for (float remainingTime = moveDuration; remainingTime > 0; remainingTime -= Time.deltaTime)
        {
            yield return Falling();

            var direction3D = new Vector3(moveDirection.x, 0, moveDirection.y);

            
            direction3D = Vector3.ProjectOnPlane(direction3D, Player.Instance.GetNormalOfGround()).normalized * direction3D.magnitude;
                
            rb.AddForce(direction3D * Player.Instance.CurrentMoveForce, ForceMode.Acceleration);
            
            yield return new WaitForFixedUpdate();
        }

        if(CommandInvoker.Instance.commandsToExecute.Count > 0 
            && CommandInvoker.Instance.commandsToExecute.Peek() is CurlCommand)
        {

        }  
        else
            rb.isKinematic = true;
    }

    private IEnumerator Falling()
    {
        while(Player.Instance.IsFalling())
        {
            yield return null;
        }      
    }
}
