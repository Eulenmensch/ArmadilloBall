using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

[RequireComponent(typeof(Player))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float SmoothTime = 0;
    [SerializeField] private float MoveSpeed = 0;
    [SerializeField] private float RecenterTime = 0;
    [SerializeField] private float ZOffset = 0;

    private Vector3 inputVector;
    private Vector3 vector;

    private Player player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        inputVector = Vector3.Lerp(inputVector, vector, SmoothTime);
        transform.position += inputVector * Time.deltaTime * MoveSpeed;
    }

    public void GetCameraInput(InputAction.CallbackContext context)
    {
        var input = context.ReadValue<Vector2>();
        vector = new Vector3(input.x, 0, input.y);
    }

    public void RecenterCamera(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            transform.DOMove(player.transform.position + Vector3.forward * -ZOffset, RecenterTime, false).SetEase(Ease.InOutCubic);
        }
    }

    public void CenterCameraOnStateChange()
    {
        transform.DOMove(player.transform.position + Vector3.forward * -ZOffset, RecenterTime, false).SetEase(Ease.InOutCubic);
    }

    public void ExecuteCamFollow()
    {
        transform.DOMove(player.transform.position, SmoothTime, false);
    }
}
