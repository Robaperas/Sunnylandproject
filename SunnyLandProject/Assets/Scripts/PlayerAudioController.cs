using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    bool isJumping = false;
    private AudioSource saltar;
    private AudioSource aterrizar;
    private AudioSource agacharse;
    private AudioSource correr;
    private AudioSource recoger;
    private AudioSource saltar2;
    private AudioSource aterrizar2;
    private int aleatorio;
    private AudioSource[] sources;
    

    // Start is called before the first frame update
    void Start()
    {
        sources = GetComponents<AudioSource>();
        saltar = sources[0];
        aterrizar = sources[1];
        agacharse = sources[2];
        correr = sources[3];
        recoger = sources[4];
        saltar2 = sources[5];
        aterrizar2 = sources[6];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // trigger your landing sound here !
    public void OnLanding() {
        isJumping = false;
        aleatorio = Random.Range(1,100);
        if(aleatorio>50)
        {
            aterrizar.Play();

        }
        else{
            aterrizar2.Play();

        }
       
        print("the fox has landed");
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        agacharse.Play();
        print("the fox is crouching");
    }
 
    // trigger your jumping sound here !
    public void OnJump() {
        isJumping = true;
        aleatorio = Random.Range (1,100);
        if(aleatorio>50){
            saltar.Play();
            }
            else{
                saltar2.Play();
            }

        print("the fox has jumped");
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        recoger.Play();
        print("the fox has collected a cherry");
    }
}
