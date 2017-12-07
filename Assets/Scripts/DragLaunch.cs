using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart,dragEnd;
	private float startTime, endTime;

	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void Movestart(float amount) {
		if (ball.inPlay==false)
		{
			Debug.Log ("Ball moved "+amount+" pixels");
			ball.transform.Translate (new Vector3(amount,0,0));
		}
	}

	public void DragStart() {
		//Capture Time and Position at drag start
		dragStart = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd() {
		//Capture Time and Position at drag end
		float dragDuration,lauchspeedX,lauchspeedZ;
		Vector3 lauchVelocity;

		dragEnd=Input.mousePosition;
		endTime = Time.time;

		dragDuration = endTime - startTime;
		lauchspeedX = (dragEnd.x - dragStart.x) / dragDuration;
		lauchspeedZ = (dragEnd.y - dragStart.y) / dragDuration;
		lauchVelocity = new Vector3 (lauchspeedX,0,lauchspeedZ);
		if (ball.inPlay==false) {
			ball.Lauch (lauchVelocity);
		}

	}
	void Update () {
		
	}
}
