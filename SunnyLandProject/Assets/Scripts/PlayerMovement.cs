using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	public bool jump = false;
	public bool crouch = false;
	private AudioSource[] sources;
	private AudioSource correr;
	private float instspeed;
	private Rigidbody2D rb;
	private bool moviendo =false;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sources = GetComponents<AudioSource>();
        correr = sources[3];
    }
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{		
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	public void OnLanding() {
		animator.SetBool("IsJumping", false);
	}


	public void OnCrouching(bool isCrouching) {
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		
        //if(animator.speed > 0 && !animator.isJumping)
		instspeed = rb.velocity.magnitude;
        if(((int)instspeed>0) && (!animator.GetBool("IsJumping")))
		{
			Debug.Log("speed: " + instspeed.ToString());
            if(!correr.isPlaying) correr.Play();
        }
        else{
            if(correr.isPlaying) correr.Pause();
        }
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
