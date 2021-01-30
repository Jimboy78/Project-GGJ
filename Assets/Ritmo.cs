using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ritmo : MonoBehaviour
{    

    public int wincon = 8;
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
    //Cantidad de beats que erraste en este lvl
    private int current_misses;

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
    public float hit_window = 0.2f;

    public GameObject fondo;

    public GameObject fondo_izq;
    
    public GameObject fondo_der;

    public GameObject Biome_change;
/*
    public Material Bioma2;

    public Material Piedra2_izq;

    public Material Piedra2_der;
*/
    public List<Material> Biomas = new List<Material>();

    public List<Material> Biomas_Paredes = new List<Material>();

    void Start()
    {
        Biomas.Add((Material)Resources.Load("Bioma1", typeof(Material)));
        
        Biomas_Paredes.Add((Material)Resources.Load("Bioma1", typeof(Material)));

        Biomas.Add((Material)Resources.Load("Bioma2", typeof(Material)));
        
        //Importo el objeto Boton
        boton = GameObject.Find("Boton");

        fondo = GameObject.Find("Background");

        fondo_izq = GameObject.Find("Background_izq");

        fondo_der = GameObject.Find("Background_der");

        Biome_change = GameObject.Find("Biome_change");

        //Periodo esperado del beat
        period = (bpm/60f)*0.5f;
        //Velocidad
        maintrack.pitch = 0.95f;
        //Contador de wincon (cada 1 )
        wincounter = 0;
        losecounter = 0;
        beat_per_lvl = 10;
        rate4win = 0.7f; //0.7f
        current_hit = 0;
        current_beats = 0;
        current_misses =0;
            
        fondo_izq.GetComponent<Scroller>().base_accel(0.2f);
        fondo_der.GetComponent<Scroller>().base_accel(0.2f);
        fondo_der.GetComponent<Scroller>().flip();
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
        else if(Input.GetKeyDown("space")){
            current_misses +=1;
        }
        //Fin de bloque
        if((current_beats == beat_per_lvl  || current_misses>= (beat_per_lvl-(rate4win*beat_per_lvl)) ) && !score_changed){
            score_changed = true;

            Debug.Log($"IF =  {beat_per_lvl*rate4win} current hit {current_hit} current_misses {current_misses} current beat {current_beats}");

            if(beat_per_lvl*rate4win<=current_hit){
                Debug.Log(maintrack.pitch +  "speed " + speed_increase);

                //StartCoroutine(Biome_change.GetComponent<Flash>().flashear());
                wincounter += 1;
                fondo.GetComponent<MeshRenderer> ().material = Biomas[wincounter];
                maintrack.pitch += speed_increase;
                fondo.GetComponent<Scroller>().accel_speed(speed_increase*wincounter);
                fondo_izq.GetComponent<Scroller>().accel_speed(speed_increase*wincounter);
                fondo_der.GetComponent<Scroller>().accel_speed(speed_increase*wincounter);
                

            }
            else{
                if(current_hit == 0){
                    losecounter +=1;
                }
                losecounter += 1;
            }

            current_hit = 0;
            current_beats = 0;
            current_misses = 0;
            Debug.Log("Win=" + wincounter + "Lose=" + losecounter);
        }
        //ventanas de hiteo
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
            boton.GetComponent<Boton>().Color(255,255,255,1);
        }
        //Win - Lose
        if(wincounter > wincon){
            Debug.Log("Ganaste perro");
        }
        else if( losecounter > losecon){
            Debug.Log("Perdiste perro");
        }
    }
}
