using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visionScript : MonoBehaviour
{

    Rigidbody2D LostRb2d;
    public float sightDowngrade = 0.05f;
    public float sightDowngradeTime = 0.1f;
    public float minSight = 2;
    public float maxSight = 10;
    public float sightImprov = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(5,5,5);
        var bat = GameObject.Find("Lost");
        LostRb2d= bat.GetComponent<Rigidbody2D>();

        StartCoroutine(downgradeSightCoroutine());
        // StartCoroutine(improveSightCoroutine());
    }

    public void improveSight(){
        
        if (transform.localScale.x>10){
            transform.localScale = new Vector3(maxSight,maxSight,maxSight);
        }
        else{
            transform.localScale += new Vector3(sightImprov,sightImprov,sightImprov);
        }
    }
    public void downgradeSight(){
        
        if (transform.localScale.x<=2){
            transform.localScale = new Vector3(minSight,minSight,minSight);
        }
        else{
            transform.localScale -= new  Vector3(sightDowngrade,sightDowngrade,sightDowngrade);
        }
    }
    
    void Update()
    {
        transform.position = new Vector2(LostRb2d.position.x-1.2f,LostRb2d.position.y+0.5f);
    }



     IEnumerator downgradeSightCoroutine()
     {
         while (true)
             {
               yield return new WaitForSeconds(sightDowngradeTime);
               downgradeSight();
             }
     }
}
