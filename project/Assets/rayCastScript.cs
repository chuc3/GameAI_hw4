using UnityEngine;
using System.Collections;

public class rayCastScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//RaycastHit hit;
		//if (Physics.Raycast (transform.position, transform.up.normalized, out hit))
		RaycastHit2D hit = Physics2D.Raycast(transform.localPosition,transform.up);
			print (hit.distance);

		//Debug.DrawRay(transform.localPosition, transform.forward.normalized * 10f, Color.cyan);
	}
	void FixedUpdate(){
		Debug.DrawRay(transform.localPosition, transform.up.normalized, Color.red);
	}
}
