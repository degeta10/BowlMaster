using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 speed;
	[HideInInspector]
	public bool inPlay=false;

	private Rigidbody rb;
	private AudioSource ballsound;
	private Vector3 ballStartPos;


	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		ballsound = GetComponent<AudioSource> ();
		rb.useGravity = false;
		ballStartPos = transform.position;
	}

	public void Lauch (Vector3 velocity)
	{
		inPlay = true;
		rb.useGravity = true;
		rb.velocity = velocity;
		ballsound.Play ();
	}

	public void Reset()
	{
		Debug.Log ("Ball Reset");
		inPlay = false;
		transform.position = ballStartPos;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
