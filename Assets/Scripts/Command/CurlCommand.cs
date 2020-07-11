using UnityEngine;
using System.Collections;

public class CurlCommand : ICommand
{
    public CurlCommand()
    {

    }

    public IEnumerator Execute()
    {
        Player.Instance.ToggleCurlAbility();

        //Play Curling Animation
        yield return WaitForEndOfMovement();

        //Play Uncurling Animation

        Player.Instance.ToggleCurlAbility();
    }

    public IEnumerator WaitForEndOfMovement()
    {
        while(Vector3.Magnitude(Player.Instance.rb.velocity) > 0.05f
            || !IsOnEvenGround())
        {
            yield return null;
        }
        Player.Instance.rb.isKinematic = true;
    }

    private bool IsOnEvenGround()
    {
        RaycastHit raycastHit;

        if(Physics.Raycast(Player.Instance.transform.position, Vector3.down, out raycastHit, 0.51f))
        {
            //raycastHit.normal;
        }
        return false;
    }
}
