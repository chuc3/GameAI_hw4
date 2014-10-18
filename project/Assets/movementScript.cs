using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movementScript : MonoBehaviour {
	//public GameObject waypoints;
	GameObject waypoints;
	public List<Transform> pts;
	int pos;
	// Use this for initialization
	void Start () {
		waypoints = GameObject.FindGameObjectWithTag ("waypoints");
		for (int x=0;x< waypoints.transform.childCount;x++)
			pts.Add (waypoints.transform.GetChild(x).gameObject.transform);
		pos = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (pos == pts.Count)
			Time.timeScale = 0; // puase game when reaches the end
		else if (transform.position != pts [pos].position)
			transform.position = Vector3.MoveTowards (transform.position,pts[pos].position,.25f	);
		else
			pos++;
	}
}
