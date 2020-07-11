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
        RaycastHit raycastHit;

        

        if(Physics.Raycast(Player.Instance.transform.position, Vector3.down, out raycastHit, 0.6f))
        {
            if (Vector3.Dot(raycastHit.normal, Vector3.up) > 0.99)
                return true;
        }
        return false;
    }
}
