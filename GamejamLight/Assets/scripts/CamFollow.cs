using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform target; // The target the camera will follow
    [SerializeField] float smoothSpeed = 0.125f; // Smoothness of the camera movement
    [SerializeField] Vector3 offset; // Offset from the target

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position based on target position and offset
            Vector3 desiredPosition = target.position + offset;
            // Smoothly transition to the desired position using SmoothDamp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Update the camera position
            transform.position = smoothedPosition;
        }
    }
}
 
