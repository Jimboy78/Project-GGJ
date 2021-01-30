using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-3f,3f)]
    public float scrollSpeed = 0.3f;
    private float base_scrollSpeed;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        //Debug.Log(transform.localScale);
        base_scrollSpeed = scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed);
        mat.SetTextureOffset("_MainTex",new Vector2(0,offset));
        Debug.Log(scrollSpeed); 

    }

    public void accel_speed(float p){
        scrollSpeed = base_scrollSpeed * (1f+p)*2;
    }

    public void base_accel(float p){
        scrollSpeed *= (1f+p); 
    }
}
