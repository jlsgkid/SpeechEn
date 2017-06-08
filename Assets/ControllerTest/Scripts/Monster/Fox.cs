using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

	public enum State
	{
		IDLE,
		WALK,
		ATTACK,
		DIE
	}
	public State state;
	private Animation anim;
	[SerializeField]
	private Transform player;
	public float walkSpeed = 5.0f;
	[SerializeField]
	private int life = 100;


	// Use this for initialization
	void Start () {
		state = State.IDLE;
		anim = this.GetComponent<Animation> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//player and fox distance
		float dis = Vector3.Distance(transform.position, player.position);
		//Debug.Log (dis);
		if (dis < 17 && dis > 3) {
			state = State.WALK;
			WalkToPlay ();
		} else if (dis < 3) {
			state = State.ATTACK;
		} else {
			state = State.IDLE;
		}
		if(life <= 0){
			state = State.DIE;
		}
		//set animation
		AnimationControl();

	}

	void WalkToPlay(){
		transform.rotation = Quaternion.Slerp(transform.rotation, 
			Quaternion.LookRotation(player.position-transform.position), walkSpeed * Time.deltaTime);
		transform.position += transform.forward * walkSpeed * Time.deltaTime;
	}

	public void GetDamage(int damage){
		if (this.life > 0) {
			this.life -= damage;
		} else {
			state = State.DIE;
		}
	}

	private void AnimationControl(){

		switch (state) {
		case State.IDLE:
			anim.Play ("idleLookAround");
			break;
		case State.WALK:
			anim.Play ("run");
			break;
		case State.ATTACK:
			anim.Play ("agressiveJumpBite");
			break;
		case State.DIE:
			anim.Play ("death");
			break;
		}
	}


}
