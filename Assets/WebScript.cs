using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    Scroller playerScript;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject masterGame = GameObject.Find("Background");
        playerScript = masterGame.GetComponent<Scroller>();

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(0,-playerScript.scrollSpeed*49);
    }

     void OnBecameInvisible() {
         Destroy(gameObject);
     }
}
