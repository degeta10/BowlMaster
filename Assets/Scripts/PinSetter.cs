using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public int lastStandingCount = -1;

	private bool BallEnteredBox = false;
	private float lastChangeTime;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	public int CountStanding(){
		int standing = 0;
		foreach (Pins pin in GameObject.FindObjectsOfType<Pins>()) {
			if (pin.isStanding()) {
				standing++;
			}
		}
		return standing;
	}

	void CheckStanding(){
		int currentStanding = CountStanding ();
		if (currentStanding!=lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;
		if ((Time.time-lastChangeTime)>settleTime) {
			PinsHaveSettled ();
		}
	}

	void PinsHaveSettled(){
		ball.Reset ();
		lastStandingCount = -1;
		BallEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	void OnTriggerExit(Collider collider) {		
		Debug.Log ("Pin Left");
		GameObject thingLeft = collider.gameObject;
		if (thingLeft.GetComponent<Pins>()) {
			Destroy (thingLeft);
		}
	}

	void OnTriggerEnter(Collider collider) {
		GameObject thingHit = collider.gameObject;
		if (thingHit.GetComponent<Ball>()) {
			BallEnteredBox = true;
			standingDisplay.color = Color.red;
			Debug.Log ("Ball Entered");
		}
	}
	// Update is called once per frame
	void Update () 
	{
		standingDisplay.text = CountStanding ().ToString ();
		if (BallEnteredBox) {
			CheckStanding ();
		}
	}
}
