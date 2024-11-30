using UnityEngine;

public class FollowCameraRotation : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        transform.rotation = cameraTransform.rotation;
    }
}
