using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeAttacker : MonoBehaviour {

	float timer = 0.0f;
	float timerMax = 1.5f;
	Transform finalDestination;

	// Use this for initialization
	public enum State {
		WALK, ATTACK
	}
	public State state;

	void Start () {
		finalDestination = GetComponent<AttackerAI> ().destination;
		state = State.WALK;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		switch (state) {
		case State.WALK:
			GetComponent<AttackerAI> ().destination = finalDestination;
			GetComponent<AttackerAI> ().SetDestination ();
			break;

		case State.ATTACK:

			if (GetComponent<AttackerAI> ().defender.transform != null) {
				transform.LookAt (GetComponent<AttackerAI> ().defender.transform);
				GetComponent<AttackerAI> ().destination = GetComponent<AttackerAI> ().defender.transform;	
				GetComponent<AttackerAI> ().SetDestination ();
				
			} 
			//int defHp = GetComponent<AttackerAI> ().defender.GetComponent<DefenderAI> ().hp;
			if (timer >= timerMax) {
				//defHp--;
				//Debug.Log ("attacking");
				timer = 0.0f;
				//if (GetComponent<AttackerAI> ().defender != null) {
					if (GetComponent<AttackerAI> ().defender.GetComponent<DefenderAI> ().TakeDamage (1)) {

					} else {
						state = State.WALK;
					}

			}
			//state = State.WALK;
			break;

		}
			
	}

	void OnTriggerEnter(Collider target) {

		//GetComponent<AttackerAI> ().destination = target.transform;	
		//GetComponent<AttackerAI> ().SetDestination ();
		if (target.gameObject.tag == "defender") {
			GetComponent<AttackerAI> ().destination = target.transform;	
			GetComponent<AttackerAI> ().SetDestination ();
			GetComponent<AttackerAI> ().defender = target.gameObject;
			//Debug.Log ("defender tag found");
		} else {
			state = State.WALK;
		}

		state = State.ATTACK;
		//Debug.Log ("triggered attacker");

	}


}
