using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    Scroller playerScript;
    Animator animator;

    SpriteRenderer spriteRenderer;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject masterGame = GameObject.Find("Background");
        playerScript = masterGame.GetComponent<Scroller>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(0,-playerScript.scrollSpeed*49);
    }

     void OnBecameInvisible() {
         Destroy(gameObject);
     }

    bool AnimatorIsPlaying(){
        return animator.GetCurrentAnimatorStateInfo(0).length >
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    
     IEnumerator downgradeSightCoroutine()
     {
         while (true)
             {
                yield return new WaitForSeconds(0.2f);
                Destroy(this.gameObject);
                break;
             }
     }
     public void destroyMySelf(){

        rb2d.isKinematic = true;
        animator.Play("Barril_explosion");
        StartCoroutine(downgradeSightCoroutine());

     }
}
