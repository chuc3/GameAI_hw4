using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movementScript : MonoBehaviour {
	//public GameObject waypoints;
	public int speed;
	int cnt;
	GameObject waypoints;
	public List<Transform> pts;
	int pos;
	// Use this for initialization
	void Start () {
		waypoints = GameObject.FindGameObjectWithTag ("waypoints");
		for (int x=0;x< waypoints.transform.childCount;x++)
			pts.Add (waypoints.transform.GetChild(x).gameObject.transform);
		pos = 0;
		cnt = 0;
	}

	// Update is called once per frame
	void Update () {
		bool isHit = rayCastScript.hitting;
		if (pos == pts.Count)
			Time.timeScale = 0; // puase game when reaches the end
		else if (isHit){
			transform.position = Vector2.MoveTowards(transform.position, transform.forward, Time.deltaTime*2f);
			if(cnt>10){pos++;cnt=0;}
			else cnt++;
		}
		else if (transform.position != pts [pos].position)
			transform.position = Vector3.MoveTowards (transform.position,pts[pos].position, speed*Time.deltaTime);
		else
			pos++;
		//Vector3 temp = new Vector3 (pts [pos].position.x, pts [pos].position.y, 0f);
		//transform.LookAt(temp);
	}

	void FixedUpdate()
	{
		Vector3 moveDirection = pts[pos].position - transform.position;
		if (moveDirection != Vector3.zero)
		{
			float angle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
			Quaternion rot = Quaternion.AngleAxis(-angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2f);
		}

		
	}
}
