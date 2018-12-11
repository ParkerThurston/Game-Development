using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	//Player Movement Variables
	public float YScale;
	public float XScale;
	public int MoveSpeed = 10;
	public float JumpHeight;

	//Player Grounded Variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public LayerMask whatIsIce;
	private bool grounded;
	private bool icegrounded;
	private bool doubleJump;
	//Non-Stick Player
	public float moveVelocity;
	public Animator animator;

	// Use this for initialization
	void Start () {
		animator.SetBool("isWalking",false);
		animator.SetBool("isJumping",false);
		XScale = transform.localScale.x;
		YScale = transform.localScale.y;
	}
	
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		icegrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsIce);
	}
	// Update is called once per frame
	void Update () {

	//This code makes the character jump
	if(Input.GetKeyDown (KeyCode.Space) && grounded||Input.GetKeyDown (KeyCode.Space) && icegrounded ){
		Jump();	
	}	

	//Double jump code
	
	if (grounded||icegrounded){
	doubleJump = false;
	animator.SetBool("isJumping",false);
	}
	
	if (Input.GetKeyDown(KeyCode.Space)&& !doubleJump && !grounded){
		Jump();
		doubleJump = true;
	}
	
	//moveVelocity=0f;
	//movement
	if(Input.GetKey(KeyCode.D)){
		GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		animator.SetBool("isWalking",true);
	//moveVelocity = MoveSpeed;
	}
	else if (Input.GetKeyUp(KeyCode.D)){
	animator.SetBool("isWalking",false);
	}
	if(Input.GetKey(KeyCode.A)){
		GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed,GetComponent<Rigidbody2D>().velocity.y);
		animator.SetBool("isWalking",true);
	//moveVelocity=-MoveSpeed;
	}
	else if (Input.GetKeyUp(KeyCode.A)){
	animator.SetBool("isWalking",false);
	}
	//GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity,GetComponent<Rigidbody2D>().velocity.y);

	//no slide
	if(grounded && !Input.GetKey(KeyCode.A) || grounded && !Input.GetKey(KeyCode.D)){
		GetComponent<Rigidbody2D>().velocity = new Vector2((GetComponent<Rigidbody2D>().velocity.x)/1.3f,(GetComponent<Rigidbody2D>().velocity.y));
	}
	else if(!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D)){
		GetComponent<Rigidbody2D>().velocity = new Vector2((GetComponent<Rigidbody2D>().velocity.x)/1.05f,(GetComponent<Rigidbody2D>().velocity.y));
	}
	
	//Player flip
	if(GetComponent<Rigidbody2D>().velocity.x>0){
		transform.localScale = new Vector3(XScale,YScale,1f);
	}
	else if(GetComponent<Rigidbody2D>().velocity.x<0){
		transform.localScale = new Vector3(-XScale,YScale,1f);
	}
	}
	
	public void Jump(){
	GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,JumpHeight);
	animator.SetBool("isJumping",true);
   }
	
}
