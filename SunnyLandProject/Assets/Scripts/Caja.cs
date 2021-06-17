using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource moviendo;
    private AudioSource golpe1;
    private AudioSource golpe2;
    private AudioSource golpe3;
    private AudioSource choque;
    private AudioSource[] sources;
    private float instspeed = 0;
    private float newvolume =0;
    private int aleatorio;
    // Start is called before the first frame update
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sources = GetComponents<AudioSource>();
        moviendo = sources[0];
        golpe1 = sources[1];
        golpe2 = sources[2];
        golpe3 = sources[3];
        choque = sources[4];        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        instspeed = rb.velocity.magnitude;
        if((int)instspeed>0)
        {
            Debug.Log("caja moviendose");
            moviendo.volume = (1-(1/Mathf.Exp(instspeed)));
            //moviendo.volume = newvolume;
            if (!moviendo.isPlaying) moviendo.Play();
        }
        else
        {
            if (moviendo.isPlaying) moviendo.Pause();
        }
    }
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("caja colision");
        //golpe1.Play();
        aleatorio = Random.Range(1,4);
        if((aleatorio >= 1) && (aleatorio < 2)) golpe1.Play();
        if((aleatorio >= 2 ) && (aleatorio < 3)) golpe2.Play();
        if(aleatorio >=3) golpe3.Play();
    }
}
