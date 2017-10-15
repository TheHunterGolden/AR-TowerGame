using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour {

	// Use this for initialization
	GameObject enemy;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy != null) {
			transform.position = Vector3.Lerp (transform.position, enemy.transform.position, 0.3f);

		}
	}

	public void setEnemy(GameObject enemy) {
		this.enemy = enemy;
	}


		

}
