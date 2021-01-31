using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostController : MonoBehaviour
{

    private GameObject miss;
    private GameObject ritmo;
    public AnimationCurve moveCurve;
    [System.NonSerialized]
    public float step;
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
        miss = GameObject.Find("Miss");
        ritmo = GameObject.Find("track120bpm");
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        var missPos = miss.transform.position;
        var missTopPos = missPos + spriteRenderer.bounds.min;
        step = Mathf.Abs(transform.position.y - missTopPos.y) / ritmo.GetComponent<Ritmo>().losecon;
        Debug.Log(step);
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
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    public IEnumerator SmoothMovement(Rigidbody2D rigidBody, Vector2 endPosition, float duration)
    {
        float elapsed = 0F;
        Vector2 startPosition = transform.position;

        while (elapsed < duration)
            {
            Vector2 newPosition = new Vector2(rigidBody.transform.position.x,rigidBody.transform.position.y-0.8f* Time.deltaTime);
            rigidBody.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
