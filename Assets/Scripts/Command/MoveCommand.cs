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
        RaycastHit raycastHit;

        var rb = Player.Instance.rb;
        rb.isKinematic = false;

        for (float remainingTime = moveDuration; remainingTime > 0; remainingTime -= Time.deltaTime)
        {
            //if (remainingTime / moveDuration > 0.1)
            //{
                var direction3D = new Vector3(moveDirection.x, 0, moveDirection.y);

                if (Physics.Raycast(Player.Instance.transform.position, Vector3.down, out raycastHit, 0.51f))
                {
                    direction3D = Vector3.ProjectOnPlane(direction3D, raycastHit.normal).normalized * direction3D.magnitude;
                }
                
                rb.AddForce(direction3D * Player.Instance.CurrentMoveForce, ForceMode.Acceleration);
            //}
            yield return Falling();
            yield return new WaitForFixedUpdate();
        }

        if(CommandInvoker.commandsToExecute.Count > 0 
            && CommandInvoker.commandsToExecute.Peek() is CurlCommand)
        {

        }  
        else
            rb.isKinematic = true;
    }

    private IEnumerator Falling()
    {
        while(!Physics.Raycast(Player.Instance.transform.position, Vector3.down, 0.51f))
        {
            yield return null;
        }      
    }

    public IEnumerator WaitForEndOfMovement()
    {
        while (Vector3.Magnitude(Player.Instance.rb.velocity) > 0.05f)
        {
            yield return null;
        }
        Player.Instance.rb.isKinematic = true;
    }
}
