using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed;

	private Rigidbody2D rb2d;
	private Vector2 moveVelocity;

	void Start()
	{

		rb2d = GetComponent<Rigidbody2D>();

	}

	void Update()
		{
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveVelocity = moveInput.normalized * speed;

		
		}

	void FixedUpdate() 
	{

		rb2d.MovePosition(rb2d.position + moveVelocity * Time.fixedDeltaTime);

	}




}	
	


