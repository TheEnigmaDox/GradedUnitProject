using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TommyController : MonoBehaviour
{
    // Index for cycling through audio clips
    int audioIndex = 4;

    // Player status flags
    public bool isSwimming = false;
    public bool playerControl = true;
    public bool isDrunk = false;
    public bool onSpeed = false;
    public bool onHeroin = false;

    // Movement speed of the player
    public float moveSpeed = 250f;

    // Timers for different intoxication effects
    public float alcoholTimer;
    public float speedTimer;
    public float heroinTimer;

    // List of walking sound clips
    public List<AudioClip> walkSounds = new List<AudioClip>();

    // Direction of movement and offset when drunk
    [SerializeField] Vector2 direction;
    [SerializeField] Vector2 drunkOffset;
    [SerializeField] Vector2 minPos;
    [SerializeField] Vector2 maxPos;

    // Audio source component for playing sounds
    AudioSource tommyAudio;

    // References to other components and scripts
    SceneLoader sceneLoader;
    Rigidbody2D tommyRB;
    Animator tommyAnim;

    // Start is called before the first frame update
    void Start()
    {
        // Get components attached to the same GameObject
        tommyRB = GetComponent<Rigidbody2D>();
        tommyAnim = GetComponent<Animator>();
        tommyAudio = GetComponent<AudioSource>();

        // Find the SceneLoader script in the scene
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
                Mathf.Clamp(transform.position.y, minPos.y, maxPos.y));

        // Handle player input for movement direction
        if (playerControl)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        // Animate the character based on movement direction
        if (direction != Vector2.zero)
        {
            AnimateCharacter();
        }
        else
        {
            tommyAnim.SetBool("isMoving", false);
        }

        // Check if the player is in the swimming scene
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            tommyAnim.SetBool("isSwimming", true);
            isSwimming = true;
        }
    }

    // FixedUpdate is called at a fixed interval and is used for physics calculations
    void FixedUpdate()
    {
        MoveCharacter();
    }

    // Handles the movement and various status effects of the character
    void MoveCharacter()
    {
        AnimateCharacter();

        // Handle drunk status
        if (isDrunk)
        {
            if (alcoholTimer > 0)
            {
                alcoholTimer -= Time.deltaTime;
            }
            else
            {
                isDrunk = false;
                drunkOffset = Vector2.zero;
            }
        }

        // Handle speed status
        if (onSpeed)
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

        // Handle heroin status
        if (onHeroin)
        {
            if (heroinTimer > 0)
            {
                moveSpeed = 150f;
                heroinTimer -= Time.deltaTime;
            }
            else
            {
                moveSpeed = 250f;
            }
        }

        // Apply velocity to the Rigidbody2D component based on the direction and speed
        tommyRB.velocity = moveSpeed * Time.deltaTime * (direction.normalized + drunkOffset.normalized);

        // Play walking sound if the player is moving and not swimming
        if (direction != Vector2.zero && !tommyAudio.isPlaying && SceneManager.GetActiveScene().buildIndex != 3)
        {
            PlayNextClip();
        }
    }

    // Animates the character based on movement direction and status effects
    void AnimateCharacter()
    {
        if (direction != Vector2.zero && !isDrunk)
        {
            tommyAnim.SetBool("isMoving", true);
            tommyAnim.SetFloat("xInput", direction.x);
            tommyAnim.SetFloat("yInput", direction.y);
        }
        else if (direction == Vector2.zero)
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
        else if (direction == Vector2.zero)
        {
            tommyAnim.SetBool("isMoving", false);
        }
    }

    // Generates a drunk movement offset based on the direction
    Vector2 DrunkMovement(Vector2 direction)
    {
        return new Vector2(Mathf.Sin(direction.y * Time.time) * 2, Mathf.Sin(direction.x * Time.time) * 2);
    }

    // Plays the next walking sound clip in the list
    void PlayNextClip()
    {
        if (walkSounds.Count == 0)
        {
            return;
        }

        tommyAudio.clip = walkSounds[audioIndex];
        tommyAudio.Play();

        audioIndex--;

        if (audioIndex <= 0)
        {
            audioIndex = walkSounds.Count - 1;
        }
    }
}