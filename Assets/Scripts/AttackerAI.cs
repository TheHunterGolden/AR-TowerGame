using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class AttackerAI : MonoBehaviour {

	[SerializeField]
	public Transform destination;

	NavMeshAgent agent;
	public GameObject defender;
	// Use this for initialization
	public RectTransform healthBar;
	public int hp;

	void Start () {
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);

		hp = 10;
		agent = this.GetComponent<NavMeshAgent> ();
		if (agent == null) {
			Debug.Log ("AGENT NOT FOUND");
		}
		else {
			SetDestination ();
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetDestination() {
		if (destination != null) {
			Vector3 targetVector = destination.transform.position;
			agent.SetDestination (targetVector);
		}
	}

	public bool TakeDamage (int amount) {
		if (hp > 1) {
			hp = hp - amount;
			healthBar.sizeDelta = new Vector2(hp * 10, healthBar.sizeDelta.y);
			return true;
		} 
		else {
			Destroy (gameObject);
		}
		return false;
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "bullet") {
			//Debug.Log ("kill me");
			Destroy (col.gameObject);
			if (TakeDamage (1)) {
			}
		}
	}
}
