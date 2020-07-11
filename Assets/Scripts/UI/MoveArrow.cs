using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField] GameObject Tip;
    [SerializeField] GameObject Body;
    [SerializeField] float LengthMultiplier;

    public void SetArrowLength(float _length)
    {
        var scale = Body.transform.localScale;
        Body.transform.localScale = new Vector3(scale.x, _length * LengthMultiplier, scale.z);
        Tip.transform.localPosition = new Vector3(0, 0.05f, Body.transform.localScale.y * 0.55f);
    }
    public void SetArrowDirection(Vector3 _direction)
    {
        transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
    }
}
