﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
	public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playermoving;
	private Vector2 lastMove;
	private Vector2 attackmove;

	private bool attacking;
	public  float attackTime;
	private float attackTimeCounter;

	// Start is called before the first frame update
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		playermoving = false;

		if (!attacking)
		{

			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				//transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * currentMoveSpeed * Time.deltaTime, 0f, 0f));
				myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
				playermoving = true;
				lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			}

			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
			{
				//transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * currentMoveSpeed * Time.deltaTime, 0f));
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,Input.GetAxisRaw("Vertical") * moveSpeed);
				playermoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			}
			if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
			{
				myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
			}
			if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
			{
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
			}





			if (Input.GetKeyDown(KeyCode.Space))
			{
				attackTimeCounter = attackTime;
				attacking = true;
				anim.SetBool("Attack", true);
			}

			if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
			{
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			}
			else
			{
				currentMoveSpeed = moveSpeed;
			}

		}
				

		if (attackTimeCounter > 0)
		{
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0)
		{
			attacking = false;
			anim.SetBool("Attack", false);
		}



		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("PlayerMoving", playermoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}
}
