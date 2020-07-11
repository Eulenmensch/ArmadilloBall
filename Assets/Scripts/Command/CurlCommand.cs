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

        if(Player.Instance.IsCurled)
        {
            //Play Curling Animation
            yield return new WaitForSeconds(1f);
            yield return WaitForEndOfMovement();
        }
        else
        {
            //Play Uncurling Animation
            yield return new WaitForSeconds(1f);
        }
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
