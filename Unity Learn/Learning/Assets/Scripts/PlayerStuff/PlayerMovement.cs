using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //This is all universally declared, anything within the script can refer to these
    Rigidbody rb;
    float moveSpeed = 5f; // [SerializeField] = easily editable inputs within unity
    public float jumpForce = 5f;
    public float currentMoveSpeed;
    public float SprintSpeed = 1f;
    public bool LevelUp = false;
    

    public bool Backwards = false;
    float Spun = 1f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    
    void Start()
    {
        // Start is called before the first frame update
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelingUp();
        Sprint();
        Reverse();
        currentMoveSpeed = moveSpeed * SprintSpeed * Spun;
        //Input.GetAxis = to Unity made refereances to button inputs
        float leftOrRight = Input.GetAxis("Horizontal");
        float forwardOrBack = Input.GetAxis("Vertical");

        //Handles both, left and right, and forward and backward movement
        //due to "Horizontal" and "Vertical" returning either 1 or -1 dependent on what buttons are pressed
        rb.velocity = new Vector3(leftOrRight * currentMoveSpeed, rb.velocity.y, forwardOrBack * currentMoveSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded()) // "&&" = both conditions
                                                         // need to be true
        {
            jump();
        }

    }

    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        //"rb.velocity.x & y = keep velocity == last frame
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            jump();
        }
    }

    bool IsGrounded() // checks to see if the player is on the ground
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
        // returns true or false
    }
    
    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            SprintSpeed = 1.5f; 
        }
        else
        {
            SprintSpeed = 1f;
        }
    }
    void Reverse()
    {
        if (Backwards == true)
        {
            Spun = -1f;
        }
        else
        {
            Spun = 1f;
        }
    }
    void LevelingUp()
    {
        if (LevelUp == true)
        {
            LevelUp = false;
            moveSpeed += 1;
            jumpForce += 0.25f;

        }
    }
    
}
