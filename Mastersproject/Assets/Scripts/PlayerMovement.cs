using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    //public GameObject player;

    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayers;

    [HideInInspector] public bool isFacingRight = true;

    public bool doubleJumpAllowed = false;
    float mx;

    /*lic void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject.CompareTag("Platform") && Input.GetButtonDown("Jump"))
         {
             anim.SetBool("Jump", false);
             feet.transform.parent = other.gameObject.transform;
         }
     }

     private void OnTriggerExit2D(Collider2D other)
     {
         if (other.gameObject.CompareTag("Platform"))
         {
             feet.transform.parent = null;
         }
     } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }*/

    private void Update()
    {
        if (IsGrounded())
        {
            doubleJumpAllowed = true;
        }

        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        else if (Input.GetButtonDown("Jump") && doubleJumpAllowed)
        {
            Jump();
            doubleJumpAllowed = false;
        }

        if (Mathf.Abs(mx) > 0.05)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
        if (mx > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFacingRight = true;
        }
        else if (mx < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFacingRight = false;
        }
        anim.SetBool("isGrounded", IsGrounded());
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }
    public void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }
    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spike")
        {
            LevelManager.instance.Respawn();
        }
    }*/
}
