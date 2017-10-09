using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhalePodMove : MonoBehaviour {

    public float speed = 50f;

    Vector3 position;
	void Start () {

        position = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        position.y = Mathf.Sin(Time.time) * 100f;
        transform.position = position;

	}
}
