using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TommyController : MonoBehaviour
{
    public bool playerControl = true;
    public bool isDrunk = false;
    public bool onSpeed = false;
    public bool onHeroin = false;

    public float moveSpeed = 250f;

    public float alcoholTimer;
    public float speedTimer;
    public float heroinTimer;

    [SerializeField] Vector2 direction;
    [SerializeField] Vector2 drunkOffset;

    Rigidbody2D tommyRB;
    Animator tommyAnim;

    // Start is called before the first frame update
    void Start()
    {
        tommyRB = GetComponent<Rigidbody2D>();  
        tommyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControl)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); 
        }

        if(direction !=  Vector2.zero)
        {
            AnimateCharacter();
        }
        else
        {
            tommyAnim.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        AnimateCharacter();

        if(isDrunk)
        {
            if(alcoholTimer > 0)
            {
                alcoholTimer -= Time.deltaTime;
            }
            else
            {
                isDrunk = false;
                drunkOffset = Vector2.zero; 
            }
        }

        if(onSpeed)
        {
            if (speedTimer > 0)
            {
                //moveSpeed = 450f;
                speedTimer -= Time.deltaTime;
            }
            else
            {
                moveSpeed = 250f;
            }
        }

        if (onHeroin)
        {
            if(heroinTimer > 0)
            {
                moveSpeed = 150f;
                heroinTimer -= Time.deltaTime;
            }
            else
            {
                moveSpeed = 250f;
            }
        }

        tommyRB.velocity = moveSpeed * Time.deltaTime * (direction.normalized + drunkOffset.normalized);
    }

    void AnimateCharacter()
    {
        if (direction != Vector2.zero && !isDrunk)
        {
            tommyAnim.SetBool("isMoving", true);
            tommyAnim.SetFloat("xInput", direction.x);
            tommyAnim.SetFloat("yInput", direction.y);
        }
        else if(direction == Vector2.zero)
        {
            tommyAnim.SetBool("isMoving", false);
        }

        if (direction != Vector2.zero && isDrunk)
        {
            direction.x = -direction.x;
            direction.y = -direction.y;
            tommyAnim.SetBool("isMoving", true);
            drunkOffset = DrunkMovement(direction);
        }
        else if(direction == Vector2.zero)
        {
            tommyAnim.SetBool("isMoving", false);
        }
    }

    Vector2 DrunkMovement(Vector2 direction)
    {
        return new Vector2(Mathf.Sin(direction.y * Time.time) * 2, Mathf.Sin(direction.x * Time.time) * 2);
    }
}
