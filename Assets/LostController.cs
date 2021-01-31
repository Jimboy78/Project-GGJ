using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool checkLeftFlag, checkRightFlag;

    [SerializeField]
    Transform leftCheck;
    [SerializeField]
    Transform rightCheck;
    
    [SerializeField]
    float Speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    private void FixedUpdate()
    {


        if (Physics2D.Linecast(transform.position, leftCheck.position, 1 << LayerMask.NameToLayer("Wall")))
            checkLeftFlag = true;
        else
            checkLeftFlag = false;


        if (Physics2D.Linecast(transform.position, rightCheck.position, 1 << LayerMask.NameToLayer("Wall")))
            checkRightFlag = true;
        else
            checkRightFlag = false;



        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            if(!checkRightFlag)
                rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
            else
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            if(!checkLeftFlag)
                rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
            else
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        else{
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        
        Destroy(other.gameObject);
    }
}
