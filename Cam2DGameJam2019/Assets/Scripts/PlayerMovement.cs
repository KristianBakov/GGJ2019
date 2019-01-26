using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	private Animator character_animator;

	float horizontal_move = 0f;

	public float run_speed = 40f;

	bool jump = false;
	bool crouch = false;

	public Collider2D player_collider;
	public Collider2D object_collider;

	void Start ()
	{
		character_animator = GetComponent<Animator>();

		player_collider = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Collider2D>();
		object_collider = GameObject.FindGameObjectWithTag("MovableBox").GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		horizontal_move = Input.GetAxisRaw("Horizontal") * run_speed;

        character_animator.SetFloat("Speed", Mathf.Abs(horizontal_move));
		character_animator.SetBool("Move", false);
		character_animator.SetBool("Push", false);
		//character_animator.SetBool("Jump", false);

		PlayerBoxCollision();

		if(Input.GetKey("d") || Input.GetKey("a"))
		{
			character_animator.SetBool("Move", true);
		}

		if(Input.GetButtonDown("Jump"))
		{
			jump = true;

			character_animator.SetBool("Jump", true);
		}

		if(Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if(Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
	}

    public void OnLanding ()
    {
        character_animator.SetBool("Jump", false);
    }
	void FixedUpdate ()
	{
		controller.Move(horizontal_move * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	void PlayerBoxCollision()
	{
		if(player_collider.IsTouching(object_collider))
		{
			character_animator.SetBool("Push", true);
		}
	}
}
