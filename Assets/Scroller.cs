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
        base_scrollSpeed = scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed);
        mat.SetTextureOffset("_MainTex",new Vector2(0,offset));

    }

    public void accel_speed(float p){
        scrollSpeed = base_scrollSpeed * (1f+p)*1.4f;
    }

    public void base_accel(float p){
        scrollSpeed *= (1f+p); 
    }

    public void update_texture(Texture t)
    {
        var rend = GetComponent<Renderer>();
        rend.material.mainTexture = t;
    }
}
