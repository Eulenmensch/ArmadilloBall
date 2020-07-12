using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem.Interactions;

public class CurlCommand : ICommand
{
    public CurlCommand()
    {

    }

    public IEnumerator Execute()
    {
        Player.Instance.ActivateCurlAbility();

        //Play Curling Animation
        yield return WaitForEndOfMovement();

        //Play Uncurling Animation

        Player.Instance.DeactivateCurlAbility();
    }

    public IEnumerator WaitForEndOfMovement()
    {
        while(Vector3.Magnitude(Player.Instance.rb.velocity) > 0.1f
            || !IsOnEvenGround())
        {
            yield return null;
        }
    }

    private bool IsOnEvenGround()
    {
        if (Vector3.Dot(Player.Instance.GetNormalOfGround(), Vector3.up) > 0.99)
                return true;
        return false;
    }
}
