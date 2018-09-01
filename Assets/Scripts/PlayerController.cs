using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * 
 * Player Controller
 * For the move and jump of the Player
 * Including ground check
 * 
 */

public class PlayerController : MonoBehaviour
{

    //speed for the moving
    public float speed;
    //Force of the Jump
    public float jumpForce;

    private float moveInput;

    private Rigidbody2D rb;

    //check the player whether or not standing on the ground
    private bool isGrounded;

    //Add a groundCheck on the bottom of the player
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //player could do multi jumps
    private int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        //initiate
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //by checking if there is overlapping between the bottom of the player and the ground layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //update the left or right move
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        //if player hit the ground, reset value of extraJumps
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        //check if user click "Space" (for jump) 
        //Do multiple jumps if the condition is satisfied
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }
}
