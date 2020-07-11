using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class QuadraticDrag : MonoBehaviour
{
    [SerializeField] private float Drag = 0;            //Quadratic force applied counter the board's velocity
    [SerializeField] private float AngularDrag = 0;     //Quadratic force applied counter the board's angular velocity

    private Rigidbody Body;

    private void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApplyQuadraticDrag();
    }

    private void ApplyQuadraticDrag()
    {
        //Apply translational drag
        Body.AddForce(-Drag * Body.velocity.normalized * Body.velocity.sqrMagnitude, ForceMode.Acceleration);
        //Apply rotational drag
        Body.AddTorque(-AngularDrag * Body.angularVelocity.normalized * Body.angularVelocity.sqrMagnitude, ForceMode.Acceleration);
    }
}