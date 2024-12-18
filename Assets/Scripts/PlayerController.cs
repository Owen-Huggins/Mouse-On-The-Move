using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    public float movementX;
    public float movementY;

    // Speed at which the player moves.
    public float speed = 0;

    public float rotationSpeed = 10f; 

    // Helps player jump, vector to go up and bool to know if touching ground
    public Vector3 jump;
    public bool isGrounded;

    private Animator anim;

    public GameObject lanuchOrigin; 

    public AudioClip[] audioClips;
    public AudioSource audioSource;

    

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody, Animator, and Input Controller components attached to the player.
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // if it is staying (on ground) changes bool
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Plays random footstep sound from the list
        int num = Random.Range(0, audioClips.Length);
        audioSource.PlayOneShot(audioClips[num], 1f);

        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x / 10;
        movementY = movementVector.y / 10;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * 10f, ForceMode.Impulse);
            anim.SetTrigger("Jump");
        }
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Rotates the player to the left or right using Q and E
        if (Input.GetKey(KeyCode.Q))
        {
            rb.transform.GetChild(0).Rotate(0, -rotationSpeed * Time.deltaTime, 0);
            lanuchOrigin.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.transform.GetChild(0).Rotate(0, rotationSpeed * Time.deltaTime, 0);
            lanuchOrigin.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

        Transform mouse = rb.transform.GetChild(0);
        lanuchOrigin.transform.position = mouse.position + mouse.forward; 

        // Create a 3D movement vector using the X and Y inputs.
        // Switched becuase Mouse game obj is rotated -90 y
        Vector3 movement = (transform.GetChild(0).transform.forward * movementY + transform.GetChild(0).transform.right * movementX);
        // Apply force to the Rigidbody to move the player.
        //rb.AddForce(movement * speed); 
        transform.position += movement * speed;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            anim.SetTrigger("Jump");
        }

        // Gets and set forward and turning from the Input Controller
        float vely = movementY;
        float velx = movementX;

        if(vely < 0f) velx = -movementX; //switch turn around if going backwards

        // Sets all variables in PlayerController    
        anim.SetFloat("velx", velx); 
        anim.SetFloat("vely", vely);
        anim.SetBool("isGrounded", isGrounded);
        if (isGrounded) anim.ResetTrigger("Jump");
    }
}
