using UnityEngine;
using System.Collections;

public class GeneraterBehaviour : MonoBehaviour {
	
	public GameObject Prefab;
	public float IntervalTime;

	private float spendTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if((spendTime += Time.deltaTime) >= this.IntervalTime){
			this.spendTime = 0;
			GameObject.Instantiate(this.Prefab, this.transform.position, Quaternion.identity);
		}
	}
}
