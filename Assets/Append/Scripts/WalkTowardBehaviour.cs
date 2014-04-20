using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class WalkTowardBehaviour : MonoBehaviour {

	[TagNameAttribute]
	public string TagName = "Player";
	public float Force = 1f;
	[Range(0, 1)]
	public float TurnSpeed = 0.1f;

	private Transform target;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag (TagName).transform;
	}

	void FixedUpdate()
	{
		var lookat = this.target.position - this.transform.position; // turn vector
		lookat = new Vector3(lookat.x, this.transform.forward.y, lookat.z) ; // DON'T MOVE Y (Up or Down)

		this.transform.forward = Vector3.Slerp (this.transform.forward, lookat, TurnSpeed); // slow turn
		this.rigidbody.AddForce (this.transform.forward * this.Force); // walk
	}
}
