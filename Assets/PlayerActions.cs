using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(PlayerInput))]
public class PlayerActions : MonoBehaviour
{
    public void OnMove()
    {
        Debug.Log("Test");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Action was started");
        else if (context.performed)
            Debug.Log("Action was performed");
        else if (context.canceled)
            Debug.Log("Action was cancelled");
    }
    IEnumerator Test()
    {
        yield return null;
    }

}
