using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour {

    Transform tf;
    public Transform target;
	void Start () {
        tf = transform;
        transform.LookAt(target);

	}
}
