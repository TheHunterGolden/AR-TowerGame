using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class DefenderAI : MonoBehaviour {

	[SerializeField]
	public Transform destination;

	NavMeshAgent agent;
	public GameObject enemy;
	public RectTransform healthBar;
	public int hp;

	// Use this for initialization
	void Start () {
		
		
		hp = 10;

		agent = this.GetComponent<NavMeshAgent> ();
		agent.Warp (destination.position);
		if (agent == null) {
			Debug.Log ("AGENT NOT FOUND");
		}
		else {
			SetDestination ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		//SetDestination ();
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
			healthBar.sizeDelta = new Vector2 (hp * 10, healthBar.sizeDelta.y);
			return true;
		} 
		else {
			Destroy (gameObject);
		}
		return false;
	}
}
