using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform leftCheck;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    private void FixedUpdate()
    {

        if (Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Ground"))){
            isGrounded = true;

        }
        else{
            isGrounded = false;
        }


        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
            if (isGrounded)
                animator.Play("player_running");
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-2,rb2d.velocity.y);
            if (isGrounded)
                animator.Play("player_running");
            spriteRenderer.flipX = true;
        }
        else
        {
            if(isGrounded)
                animator.Play("player_idle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if ((Input.GetKey("space") || Input.GetKey("up")) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x,5);
            animator.Play("player_jump");
        }
    }
}
