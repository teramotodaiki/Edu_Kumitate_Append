using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class WalkTowardBehaviour : MonoBehaviour, ICallable {

	[TagNameAttribute]
	public string TagName = "Player";
	public float Force = 1f;
	[Range(0, 1)]
	public float TurnSpeed = 0.1f;
	public bool WalkOnStart = false;

	private Transform target;
	private bool awaken = false;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag (TagName).transform;
		awaken = WalkOnStart;
	}

	void FixedUpdate()
	{
		if (awaken) {
			var lookat = this.target.position - this.transform.position; // turn vector
			lookat = new Vector3 (lookat.x, this.transform.forward.y, lookat.z); // DON'T MOVE Y (Up or Down)

			this.transform.forward = Vector3.Slerp (this.transform.forward, lookat, TurnSpeed); // slow turn
			this.rigidbody.AddForce (this.transform.forward * this.Force); // walk
		}
	}

	public void Call()
	{
		awaken = true;
	}
}
