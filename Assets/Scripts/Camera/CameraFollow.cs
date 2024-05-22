using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    // Predefined camera bounds for different orthographic sizes.
    // These comments indicate the bounds for the camera based on its orthographic size.

    //Size 2 
    //maxPos 52.4, -115
    //minPos 32.6, -135

    //size 5
    //maxPos 47, -118
    //minPos 38, -131.9

    //size 7
    //maxPos 43.5, -120
    //minPos 41.5, -129.9

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

        // Check if the current scene is the one with build index 3
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            // Adjust the camera bounds based on the current orthographic size of the camera
            switch (GetComponent<Camera>().orthographicSize)
            {
                case 2:
                    maxPos = new Vector2(52.4f, -115f);
                    minPos = new Vector2(32.6f, -135f);
                    break;
                case 5:
                    maxPos = new Vector2(47f, -118f);
                    minPos = new Vector2(38f, -131.9f);
                    break;
                case 7:
                    maxPos = new Vector2(43.5f, -120f);
                    minPos = new Vector2(41.5f, -129.9f);
                    break;
            }
        }
    }
}
