using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float SmoothTime = 0;
    private Vector3 inputVector;
    private Vector3 vector;
    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        inputVector = Vector3.Lerp(inputVector, vector, SmoothTime);
        transform.position += inputVector;
    }

    public void GetCameraInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        vector = new Vector3(input.x, 0, input.y);
    }
}
