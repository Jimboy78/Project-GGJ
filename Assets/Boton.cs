using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Color(int r , int g ,int b, float a){
        //tiene que haber una manera menos negra de usar sprite sin importarlo cada vez
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color (r, g, b, a); 
    }
}
