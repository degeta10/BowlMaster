using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {

	public float standingThreshold=3f;

	// Use this for initialization
	void Start () {
		isStanding ();
	}

	public bool isStanding()
	{
		float tiltInX, tiltInY;

		Vector3 rotationEuler = transform.rotation.eulerAngles;
		tiltInX = Mathf.Abs(270-rotationEuler.x);
		tiltInY = Mathf.Abs(rotationEuler.y);
		if (tiltInX < standingThreshold && tiltInY < standingThreshold) {
			return true;
		} else {
			return false;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
