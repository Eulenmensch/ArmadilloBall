using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField] GameObject Tip = null;
    [SerializeField] GameObject Body = null;
    [SerializeField] float LengthMultiplier = 0;

    public void SetArrowLength(float _length)
    {
        var scale = Body.transform.localScale;
        Body.transform.localScale = new Vector3(scale.x, _length * LengthMultiplier, scale.z);
        var tipPosition = Body.GetComponent<SpriteRenderer>().bounds.size;
        Tip.transform.localPosition = new Vector3(0, 0.05f, tipPosition.magnitude - 0.5f);
    }
    public void SetArrowDirection(Vector3 _direction)
    {
        transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
    }
}
