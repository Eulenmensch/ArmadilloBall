using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Vector2 moveDirection;
    private float moveDuration;


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
        if(moveDirection == Vector2.zero) yield break;

        for (float remainingTime = moveDuration; remainingTime > 0; remainingTime -= Time.deltaTime)
        {
            var direction3D = new Vector3(moveDirection.x, 0, moveDirection.y);
            Player.Instance.transform.Translate(direction3D * Time.deltaTime * Player.Instance.CurrentMoveSpeed);
            yield return null;
        }
    }
}
