using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprivedCharacterMovementConcept : MonoBehaviour
{
	public float speed;
	private Rigidbody2D myRigidbody;
	private Vector3 change;
	private Animator anim;

	// Start is called before the first frame update
	void Start()
    {
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		change = Vector3.zero;
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");
		if (change != Vector3.zero)
		{
			MoveCharacter();

			anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
			anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
			//anim.SetBool("PlayerMoving", playermoving);
			anim.SetFloat("LastMoveX", change.x);
			anim.SetFloat("LastMoveY", change.y);

		}
	}
	void MoveCharacter()
	{
		myRigidbody.MovePosition( transform.position + change * speed * Time.deltaTime);
	}
}
