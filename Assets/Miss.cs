using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Miss : MonoBehaviour
{
    private GameObject bat;
    private GameObject ritmo;
    [System.NonSerialized]
    public float step;
    public AudioSource source;
    private List<AudioClip> VoiceLines = new List<AudioClip>();
    void Start()
    {
        bat = GameObject.Find("Lost");
        ritmo = GameObject.Find("track120bpm");
        VoiceLines.Add((AudioClip)Resources.Load("Escape", typeof(AudioClip)));
        VoiceLines.Add((AudioClip)Resources.Load("HAHAHA", typeof(AudioClip)));
        VoiceLines.Add((AudioClip)Resources.Load("LetsPlay", typeof(AudioClip)));
        VoiceLines.Add((AudioClip)Resources.Load("TiredYet", typeof(AudioClip)));

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(bat.GetComponent<Rigidbody2D>().position.x, transform.position.y);
    }

    public IEnumerator flameo()
    {
        int id = 2;
        source.clip = VoiceLines[id];
        source.Play();
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(15f,20f));
            int i = (int)Random.Range(0f, (float)(VoiceLines.Count - 0.01f));
            while(i == id)
            {
             i = (int)Random.Range(0f, (float)(VoiceLines.Count - 0.01f));
            }
            id = i;
            source.clip = VoiceLines[i];
            source.Play();
        }
    }

}