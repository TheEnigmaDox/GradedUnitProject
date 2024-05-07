using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 250;

    public string direction;

    Vector2 movement = Vector2.zero;

    Rigidbody2D friendRB;
    Animator friendAnimator;

    // Start is called before the first frame update
    void Start()
    {
        friendRB = GetComponent<Rigidbody2D>();
        friendAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        friendAnimator.SetFloat("xMovement", movement.x);
        friendAnimator.SetFloat("yMovement", movement.y);

        switch(direction)
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

        friendRB.velocity = movement * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UpTrigger"))
        {
            direction = "North";
        }

        if (collision.CompareTag("DownTrigger"))
        {
            direction = "South";
        }

        if (collision.CompareTag("LeftTrigger"))
        {
            direction = "West";
        }

        if (collision.CompareTag("RightTrigger"))
        {
            direction = "West";
        }
    }
}
