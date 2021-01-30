using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color (0, 0, 0, 0); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator flashear(){
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color (0, 0, 0, 1);
        yield return new WaitForSeconds(0.01f);
        sprite.color = new Color (0, 0, 0, 0);
    }
}


