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
        }
        else
        {
            //Play Curling Animation
            yield return new WaitForSeconds(1f);
        }
    }
}
