using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ritmo : MonoBehaviour
{    

    public int wincon = 7;
    public int losecon = 4;
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

    public GameObject Lost;

    public GameObject Miss;
    public GameObject Found;

    public List<Material> Biomas = new List<Material>();

    public List<Material> Biomas_Paredes_der = new List<Material>();

    public List<Material> Biomas_Paredes_izq = new List<Material>();

    //Propiedad del kake
    visionScript vision;
    public Sprite spriteOff;
    public Sprite spriteOn ;
    void Start()
    {
        Biomas.Add((Material)Resources.Load("Bioma1", typeof(Material)));
        Biomas_Paredes_der.Add((Material)Resources.Load("B1_PD", typeof(Material)));
        Biomas_Paredes_izq.Add((Material)Resources.Load("B1_PI", typeof(Material)));

        Biomas.Add((Material)Resources.Load("Bioma2", typeof(Material)));
        Biomas.Add((Material)Resources.Load("Bioma3", typeof(Material)));
        Biomas.Add((Material)Resources.Load("Bioma4", typeof(Material)));

        //Importo el objeto Boton
        boton = GameObject.Find("Boton");

        fondo = GameObject.Find("Background");

        fondo_izq = GameObject.Find("Background_izq");

        fondo_der = GameObject.Find("Background_der");

        Biome_change = GameObject.Find("Biome_change");

        Lost = GameObject.Find("Lost");

        Miss = GameObject.Find("Miss");

        Found = GameObject.Find("Found");

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
            
        fondo_izq.GetComponent<Scroller>().base_accel(0.02f);
        fondo_der.GetComponent<Scroller>().base_accel(0.02f);


        //ACA ESTA LABURANDO EL KAKE
        var coso = GameObject.Find("iluminacion");
        vision = coso.GetComponent<visionScript>(); 


        spriteOff = Resources.Load<Sprite>("OFF");
        spriteOn = Resources.Load<Sprite>("ON");

    }



    public void gotHitByObstacle(){

        losecounter++;
        var step = Lost.GetComponent<LostController>().step;

        StartCoroutine(
            Lost.GetComponent<LostController>().SmoothMovement(
                Lost.GetComponent<Rigidbody2D>(),
                new Vector2(
                    Lost.GetComponent<Rigidbody2D>().transform.position.x,
                    -step
                ),
                step
            )
        );
                

    }
    // Update is called once per frame
    void Update()
    {
        play_time = ((float)maintrack.timeSamples / (float)mainclip.frequency);

        if(Input.GetKeyDown("space") && can_hit)
        {
            can_hit = false;
            note_played =true;
            current_hit += 1;
            vision.improveSight(); 
        }
        else if(Input.GetKeyDown("space"))
        {
            current_misses +=1;
        }
        //Fin de bloque
        if((current_beats == beat_per_lvl  || current_misses>= (beat_per_lvl-(rate4win*beat_per_lvl)) ) && !score_changed)
        {
            score_changed = true;
            Debug.Log($"IF = {beat_per_lvl*rate4win} || current hit {current_hit} || current_misses {current_misses} || current beat {current_beats}");

            //power up
            if (beat_per_lvl * rate4win <= current_hit)
            {
                wincounter += 1;
                if ((wincounter < (Biomas.Count) * 2) && ((wincounter % 2) == 0))
                {
                    fondo.GetComponent<Scroller>().update_texture(Biomas[wincounter / 2].GetTexture("_MainTex"));
                    if (wincounter == 4)
                    {
                        StartCoroutine(
                            Found.GetComponent<Found>().SmoothMovement(
                                Found.transform,
                                new Vector2(
                                    Found.transform.position.x, 55
                                ),
                            5f
                        )
                    );
                    }
                }
                maintrack.pitch += speed_increase;
                fondo.GetComponent<Scroller>().accel_speed(speed_increase * wincounter);
                fondo_izq.GetComponent<Scroller>().accel_speed(speed_increase * wincounter);
                fondo_der.GetComponent<Scroller>().accel_speed(speed_increase * wincounter);
            }

            //power down
            else
            {
                var step = Lost.GetComponent<LostController>().step;
                if (losecounter == 0)
                {
                    StartCoroutine(Miss.GetComponent<Miss>().flameo());
                }

                //critical hit!
                if (current_hit == 0)
                {
                    losecounter += 1;
                    StartCoroutine(
                        Lost.GetComponent<LostController>().SmoothMovement(
                            Lost.GetComponent<Rigidbody2D>(),
                            new Vector2(
                                Lost.GetComponent<Rigidbody2D>().transform.position.x,
                                -step
                            ),
                            step*2f
                        )
                    );
                }
                //normal
                else
                {
                    StartCoroutine(
                        Lost.GetComponent<LostController>().SmoothMovement(
                            Lost.GetComponent<Rigidbody2D>(),
                            new Vector2(
                                Lost.GetComponent<Rigidbody2D>().transform.position.x,
                                -step
                            ),
                            step
                        )
                    );
                }
                losecounter += 1;
            }

            current_hit = 0;
            current_beats = 0;
            current_misses = 0;
            Debug.Log("Win=" + wincounter + "Lose=" + losecounter);
        }
        //ventanas de hiteo
        if((play_time % period) < hit_window && !note_played)
        {

            boton.GetComponent<SpriteRenderer>().sprite = spriteOn;
            can_hit = true;
            if(!beat_changed)
            {
                current_beats +=1;
                beat_changed = true;
                score_changed = false;
            }            

        }
        else if((play_time % period) > hit_window ) {
            beat_changed = false;
            can_hit=false;
            note_played = false;
            boton.GetComponent<SpriteRenderer>().sprite = spriteOff;
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
