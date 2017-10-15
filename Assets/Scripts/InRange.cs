using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InRange : MonoBehaviour {

	DefenderAI defscript;
	float timer = 0.0f;
	float timerMax = 1.5f;

	public enum State {
		IDLE, CHASE, ATTACK
	}
	public State state;
	// Use this for initialization
	void Start () {
		defscript = GetComponent<DefenderAI> ();
		state = State.IDLE;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case State.IDLE:
			defscript.destination = gameObject.transform;
			defscript.SetDestination ();
			break;
		case State.CHASE:

			break;
		case State.ATTACK:
			if (defscript.enemy.transform != null) {
				transform.LookAt (defscript.enemy.transform);
				defscript.destination = defscript.enemy.transform;	
				defscript.SetDestination ();
			}
				
			if (timer >= timerMax) {


				if (defscript.enemy.GetComponent<AttackerAI>().TakeDamage (1)) {
					timer = 0.0f;
				} else {
					state = State.IDLE;
				}
			} 

				break;
		}
	}

	void OnTriggerEnter(Collider target){

			

		//defscript.destination = target.transform;	
		//defscript.SetDestination ();

		if (target.gameObject.tag == "enemy") {
			defscript.enemy = target.gameObject;
			defscript.destination = target.transform;	
			defscript.SetDestination ();

			//Debug.Log ("tag detected");
		}
		//Debug.Log ("triggered");
		state = State.ATTACK;
	}

}
