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
        while(Vector3.Magnitude(Player.Instance.rb.velocity) > 0.05f)
        {
            yield return null;
        }
        Player.Instance.rb.isKinematic = true;
    }
}
