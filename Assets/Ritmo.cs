using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ritmo : MonoBehaviour
{    

    public int wincon = 9;
    public int losecon = 5;
    //Contadores de victoria, a cada uno se acelera la musica
    private int wincounter;
    //Contadores de derrota , a cada uno se acerca mas el bicho
    private int losecounter;
    //Cantidad de beats por level
    private int beat_per_lvl;
    //Cantidad de beats en el level necesarios para ganar un punto (en porcentaje)
    public float rate4win;
    //Cantidad de hits que vas pegando dentro del lvl
    private int current_hit;
    //Cantidad de beats que va en en general el lvl
    private int current_beats;
    private float bpm = 120f;

    private float period;

    public float play_time ; //en segundos
    
    public AudioSource maintrack;

    public AudioClip mainclip;
    //public Boton boton;
    public GameObject boton;
    //Si esta en la ventana para hitear
    bool can_hit = false;
    
    bool note_played = false;

    bool score_changed = false;

    bool beat_changed = false;
    public float speed_increase = 0.05f;
    //tolerancia (hacia cada lado) de la ventana de hiteo, en segundos
    public float hit_window = 0.3f;
    void Start()
    {
        //Importo el objeto Boton
        boton = GameObject.Find("Boton");
        //Periodo esperado del beat
        period = (bpm/60f)*0.5f;
        //Velocidad
        maintrack.pitch = 0.95f;
        //Contador de wincon (cada 1 )
        wincounter = 0;
        losecounter = 0;
        beat_per_lvl = 10;
        rate4win = 0.7f;
        current_hit = 0;
        current_beats = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //play_time = (maintrack.timeSamples/mainclip.frequency);
        play_time = ((float)maintrack.timeSamples / (float)mainclip.frequency);

        if(Input.GetKeyDown("space") && can_hit){
            can_hit = false;
            note_played =true;
            current_hit += 1;
        }

        //Como hay 1 hit por segundo, si pasaron mas de 10+la ventana de hit 
        //(osea perdiste la oportunidad para el ultimo golpe o lo pegaste)
        if(current_beats == beat_per_lvl && !score_changed){
            score_changed = true;
            Debug.Log("IF =  " + beat_per_lvl*rate4win +"current hit" + current_hit +" current_beats  "+current_beats);
            if(beat_per_lvl*rate4win<=current_hit){
                Debug.Log(maintrack.pitch +  "speed " + speed_increase);

                maintrack.pitch += speed_increase;
                wincounter += 1;
            }
            else{
                losecounter += 1;
            }
            current_hit = 0;
            current_beats = 0;
            Debug.Log("Win=" + wincounter + "Lose=" + losecounter);
        }

        if((play_time % period) < hit_window && !note_played){
            boton.GetComponent<Boton>().Color(255,0,255,1);
            can_hit = true;
            if(!beat_changed){
                current_beats +=1;
                beat_changed = true;
                score_changed = false;
            }            

        }
        else if((play_time % period) > hit_window ) {
            beat_changed = false;
            can_hit=false;
            note_played = false;
;
            boton.GetComponent<Boton>().Color(0,0,0,1);
        }

        if(wincounter == wincon){
            Debug.Log("Ganaste perro");
        }
        else if( losecounter == losecon){
            Debug.Log("Perdiste perro");
        }
    }
}
