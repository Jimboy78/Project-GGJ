using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Miss : MonoBehaviour
{
    private GameObject bat;
    private GameObject ritmo;
    [System.NonSerialized]
    public float step;
    void Start()
    {
        bat = GameObject.Find("Lost");
        ritmo = GameObject.Find("track120bpm");
        step = Mathf.Abs(bat.transform.position.y - transform.position.y) / ritmo.GetComponent<Ritmo>().losecon;
        Debug.Log(step);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(bat.GetComponent<Rigidbody2D>().position.x, transform.position.y);
    }

    public IEnumerator flameo()
    {
        yield return new WaitForSeconds(0.01f);
    }

}