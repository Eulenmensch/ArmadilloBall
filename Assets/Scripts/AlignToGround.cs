using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToGround : MonoBehaviour
{
    private void FixedUpdate()
    {
        Vector3 groundUp = Player.Instance.GetNormalOfGround();
        transform.rotation = Quaternion.LookRotation(Player.Instance.rb.velocity.normalized, groundUp);
<<<<<<< HEAD

=======
        // Vector3 groundPos = Player.Instance.GetGroundPosition();
        // transform.position = new Vector3(transform.position.x, groundPos.y, transform.position.y)
>>>>>>> master
    }
}
