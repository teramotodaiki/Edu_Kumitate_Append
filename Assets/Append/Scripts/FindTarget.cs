using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class FindTarget : MonoBehaviour {

	[TagNameAttribute]
	public string FindTag = "Player";

	void Start()
	{
		collider.isTrigger = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == FindTag && transform.parent) {
			foreach (var item in transform.parent.GetComponents<Component>()) {
				if(item is ICallable)
					(item as ICallable).Call();
			}
		}
	}
}
