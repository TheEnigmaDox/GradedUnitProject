using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraFollowTwo : MonoBehaviour
{
    // The time it takes for the camera to interpolate to the target position
    [SerializeField] float lerpTime = 1f;

    // Minimum and maximum positions the camera can move to
    [SerializeField] Vector2 minPos;
    [SerializeField] Vector2 maxPos;

    // Offset for the camera to maintain a certain distance from the target
    Vector3 offSet = new Vector3(0, 0, -10);

    // Reference to the camera's transform
    Transform myTransform;

    // Reference to the target the camera is following
    [SerializeField] Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the camera's position is not the same as the target's position
        if (this.transform.position != target.position)
        {
            // Define the target position, maintaining the camera's current z position
            Vector3 targetPosition = new Vector3(target.position.x,
                target.position.y, transform.position.z);

            // Smoothly interpolate the camera's position towards the target position
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, lerpTime);
        }

        // Clamp the camera's position to ensure it stays within the defined bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
            Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
            transform.position.z);
    }
}
