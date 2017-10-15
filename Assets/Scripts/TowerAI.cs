using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour {


	public enum State
	{
		IDLE, ATTACK
	}

	public GameObject barrel;
	public State state;
	GameObject enemy;
	public GameObject bullet;

	public float timer = 0.0f;
	public float maxTimer = 3.0f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		switch (state) {
		case State.IDLE:
			
			break;
		case State.ATTACK:
			if (timer >= maxTimer) {
				var newBullet = Instantiate (bullet, barrel.transform.position, barrel.transform.rotation);
				newBullet.GetComponent<BulletFollow>().setEnemy (enemy);
				timer = 0.0f;
			}
			break;

		}
	}

	void OnTriggerStay (Collider target) {
	
		if (target.gameObject.tag == "enemy") {
			enemy = target.gameObject;
			state = State.ATTACK;
		} 
		else {
			//state = State.IDLE;
		}
	
	}

	void DoAttack(GameObject enemy) {
		var newBullet = Instantiate (bullet, barrel.transform.position, barrel.transform.rotation);
		newBullet.GetComponent<BulletFollow>().setEnemy (enemy);

	}
}
