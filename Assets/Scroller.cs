using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(-3f,3f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        Debug.Log(transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed)/10f;
        mat.SetTextureOffset("_MainTex",new Vector2(0,offset)); 

    }
}
