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
	private bool doubleJump;
	//Non-Stick Player
	public float moveVelocity;

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
	
	if (grounded)
	doubleJump = false;

	if (Input.GetKeyDown(KeyCode.Space)&& !doubleJump && !grounded){
		Jump();
		doubleJump = true;
	}

	if(Input.GetKey(KeyCode.D)){
	MoveRight();
	}
	else if(Input.GetKey(KeyCode.A)){
	MoveLeft();
	}
	else if(grounded && !Input.GetKey(KeyCode.A) || grounded && !Input.GetKey(KeyCode.D)){
		GetComponent<Rigidbody2D>().velocity = new Vector2((GetComponent<Rigidbody2D>().velocity.x)/1.5f,(GetComponent<Rigidbody2D>().velocity.y));
	}
	else if(!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D)){
		GetComponent<Rigidbody2D>().velocity = new Vector2((GetComponent<Rigidbody2D>().velocity.x)/1.04f,(GetComponent<Rigidbody2D>().velocity.y));
	}
	
	}
	
	public void Jump(){
	GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,JumpHeight);
    }

	public void MoveLeft(){
	GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed,GetComponent<Rigidbody2D>().velocity.y);
    }
	public void MoveRight(){
	GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed,GetComponent<Rigidbody2D>().velocity.y);
    }
}
