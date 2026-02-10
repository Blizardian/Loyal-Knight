using UnityEngine;

public class CamFollowsPlayer : MonoBehaviour
{
    [Header("Target Follow")]
    public Transform target;
    public Vector3 offset = new Vector3(0f, 8f, -6f);

    [Header("Free Camera")]
    public float panSpeed = 20f;

    [SerializeField] private bool _cameraIsLocked = true;
    void LateUpdate()
    {
        CameraLockOrUnlock();

        CameraMechanic();
    }

    /// <summary>
    /// Unlocks the camera when holding left and right mouse button, locks the camera when pressing F
    /// </summary>
    private void CameraLockOrUnlock()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            _cameraIsLocked = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _cameraIsLocked = !_cameraIsLocked;
        }
    }

    /// <summary>
    /// If the camera is locked, it follows the player, if it is unlocked the player can drag the camera accross the map
    /// </summary>
    /// <returns></returns>
    private bool CameraMechanic()
    {
        if (_cameraIsLocked)
        {
            if (target == null) return false;

            transform.position = target.position + offset;
            //transform.LookAt(target);
        }
        else if (!_cameraIsLocked)
        {
            HandleFreeCamera();
        }

        return true;
    }

    /// <summary>
    /// Camera can be dragged accross the map when holding left and right mouse button
    /// </summary>
    void HandleFreeCamera()
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 right = transform.right;
            Vector3 forward = transform.forward;

            forward.y = 0f;
            forward.Normalize();

            Vector3 move = (-right * mouseX + -forward * mouseY) * panSpeed * Time.deltaTime;

            transform.position += move;
        }
    }
}
