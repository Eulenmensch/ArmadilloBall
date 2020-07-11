using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Vector3 inputVector;
    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        transform.position += inputVector;
    }

    public void GetCameraInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        inputVector = new Vector3(input.x, 0, input.y);
    }
}
