using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	//Player Movement Variables
	public int MoveSpeed = 10;
	public float JumpHeight;

	//Player Grounded Variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	//Non-Stick Player
	//private float moveVelocity;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {

	//This code makes the character jump
	if(Input.GetKeyDown (KeyCode.Space) && grounded) {
		Jump();
	}	

	//Double jump code
	/*
	if (grounded)
	dubleJump = false;

	if (Input.GetKeyDown(KeyCode.Space)&& !doubleJpum&& !grounded){
		Jump();
		doubleJump = true;
	}
*/

	}
	public void Jump(){
	GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,JumpHeight);
    }

}
