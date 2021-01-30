using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ritmo : MonoBehaviour
{    


    private int wincounter;

    private int losecounter;

    public int beat_per_lvl;

    public float bpm = 120f;

    public float period;

    public float play_time ; //en segundos
    
    public AudioSource maintrack;

    public AudioClip mainclip;
    //public Boton boton;
    public GameObject boton;

    bool can_hit = false;

    bool note_played = false;

    public float speed_increase = 0.1f;

    //tolerancia (hacia cada lado) de la ventana de hiteo, en segundos
    public float hit_window = 0.2f;
    void Start()
    {
        //Importo el objeto Boton
        boton = GameObject.Find("Boton");
        //Periodo esperado del beat
        period = (bpm/60f)*0.5f;
        //Velocidad
        maintrack.pitch = 1f;
        //Contador de wincon (cada 1 )
        wincounter = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        //play_time = (maintrack.timeSamples/mainclip.frequency);
        play_time = ((float)maintrack.timeSamples / (float)mainclip.frequency);

        if(Input.GetKeyDown("space") && can_hit){
            can_hit = false;
            maintrack.pitch += speed_increase;
            note_played =true;
        }

        if((play_time % period) < hit_window && !note_played){
            boton.GetComponent<Boton>().Color(255,0,255,1);
            can_hit = true;
        }
        else if((play_time % period) > hit_window ) {
            can_hit=false;
            note_played = false;
            boton.GetComponent<Boton>().Color(0,0,0,1);
        }
    }
}
