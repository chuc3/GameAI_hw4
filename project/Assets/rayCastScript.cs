using UnityEngine;
using System.Collections;

public class rayCastScript : MonoBehaviour {

	public static bool hitting;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float distance;
		distance = 0f;

		RaycastHit2D hit = Physics2D.Raycast(transform.position,transform.up);
		if (hit.collider != null)
		{
			distance = Mathf.Abs(hit.point.y - transform.position.y);
			if(distance < .075f)
			{
				print (distance);
				transform.Rotate (Vector3.forward * 15);
				print ("rotate left");
				hitting = true;
			}
			else
				hitting = false;
		}

		Debug.DrawRay(transform.position, transform.up, Color.red);
	}
}
