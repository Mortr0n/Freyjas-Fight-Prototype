using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //[SerializeField] GameObject player;
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = .125f;

    void Start()
    {
        //player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position based on the player's position and offset
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;

            // Optionally, make the camera look at the player
            // transform.LookAt(target);
        }
    }
}
