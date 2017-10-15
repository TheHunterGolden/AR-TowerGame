using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	private Quaternion rotation;
	private Vector3 position;

	void Awake() {
		rotation = transform.rotation;
		position = transform.parent.position - transform.position;
	} 

	void Update () {
		//transform.LookAt (Camera.main.transform);

		transform.rotation = rotation;
		transform.position = transform.parent.position - position;
	}
}
