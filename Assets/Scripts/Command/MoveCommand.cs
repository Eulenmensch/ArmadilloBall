using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : MonoBehaviour, ICommand
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float moveDuration;
    private float moveSpeed;


    public MoveCommand(float moveDuration, Vector2 moveDirection)
    {
        this.moveDirection = moveDirection;
        this.moveDuration = moveDuration;
    }

    public IEnumerator Execute()
    {
        return MovePlayerInDirection(player.transform, moveDuration, moveDirection);
    }

    private IEnumerator MovePlayerInDirection(Transform transform, float moveDuration, Vector2 moveDirection)
    {
        for(float remainingTime = moveDuration; remainingTime > 0; remainingTime -= Time.deltaTime)
        {
            transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
            yield return null;
        }

        Debug.Log("BLA");
    }
}
