using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Vector2 moveDirection;
    private float moveDuration;
    private float moveSpeed = 5f;


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
        for(float remainingTime = moveDuration; remainingTime > 0; remainingTime -= Time.deltaTime)
        {
            var direction3D = new Vector3(moveDirection.x, 0, moveDirection.y);
            Player.Instance.transform.Translate(direction3D * Time.deltaTime * moveSpeed);
            yield return null;
        }
    }
}
