using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	//Movement Variables
	public float MoveSpeed;
	public bool MoveRight;
	//Wall Check
	public Transform WallCheck;
	public float WallCheckRadius;
	public LayerMask WhatIsWall;
	private bool HittingWall;
	//Edge Check
	private bool NotatEdge;
	public Transform EdgeCheck;
	
	// Update is called once per frame
	void Update () {
		NotatEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);

		HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

		if (HittingWall || !NotatEdge){
			MoveRight = !MoveRight;
		}

		if (MoveRight){
			transform.localScale = new Vector3(-0.5f,0.5f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else {
			transform.localScale = new Vector3(0.5f,0.5f,1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

	}
}
