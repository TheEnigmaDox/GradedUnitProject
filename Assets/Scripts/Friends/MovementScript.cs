using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Speed at which the object moves
    public float moveSpeed = 250;

    // Direction of movement as a string
    public string direction;

    // Vector to store the movement direction
    Vector2 movement = Vector2.zero;

    // Reference to the Rigidbody2D component for physics-based movement
    Rigidbody2D friendRB;
    // Reference to the Animator component for handling animations
    Animator friendAnimator;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Rigidbody2D component
        friendRB = GetComponent<Rigidbody2D>();
        // Initialize the Animator component
        friendAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the animator parameters for movement direction
        friendAnimator.SetFloat("xMovement", movement.x);
        friendAnimator.SetFloat("yMovement", movement.y);

        // Determine the movement vector based on the direction string
        switch (direction)
        {
            case "North":
                movement = Vector2.up;
                    break;
            case "South":
                movement = Vector2.down;
                    break;
            case "West":
                movement = Vector2.left;
                    break;
            case "East":
                movement = Vector2.right;
                    break;

        }

        // Apply the movement to the Rigidbody2D's velocity
        friendRB.velocity = movement * moveSpeed * Time.deltaTime;
    }

    // Method called when the object enters a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision has the "UpTrigger" tag and set direction to "North"
        if (collision.CompareTag("UpTrigger"))
        {
            direction = "North";
        }

        // Check if the collision has the "DownTrigger" tag and set direction to "South"
        if (collision.CompareTag("DownTrigger"))
        {
            direction = "South";
        }

        // Check if the collision has the "LeftTrigger" tag and set direction to "West"
        if (collision.CompareTag("LeftTrigger"))
        {
            direction = "West";
        }

        // Check if the collision has the "RightTrigger" tag and set direction to "East"
        if (collision.CompareTag("RightTrigger"))
        {
            direction = "East";
        }
    }
}
