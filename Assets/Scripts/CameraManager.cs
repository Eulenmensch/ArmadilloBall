using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera ExecuteCam = null;
    [SerializeField] CameraController cameraController;

    private bool hasBeenCentered = false;

    private void Start()
    {
        ExecuteCam.gameObject.SetActive(false);
    }
    private void LateUpdate()
    {
        if (GameManager.Instance.currentState == State.Execution)
        {
            hasBeenCentered = false;
            ExecuteCam.gameObject.SetActive(true);
            cameraController.ExecuteCamFollow();
        }
        else
        {
            ExecuteCam.gameObject.SetActive(false);
            if (!hasBeenCentered)
            {
                cameraController.CenterCameraOnStateChange();
                hasBeenCentered = true;
            }
        }
    }
}
