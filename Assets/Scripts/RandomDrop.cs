using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour {

    private bool used = false;
	// Use this for initialization
	void Start () {
        InvokeRepeating("checkForDrop", 5f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void checkForDrop()
    {
        int rand = Random.Range(0, 100);

        if(rand == (5) && !used)
        {
            used = true;
            GetComponent<Parachutes>().enabled = false;
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            BoxCollider box = gameObject.AddComponent<BoxCollider>();
            box.size = new Vector3(1.5f, 1.5f, 1.5f);
            rb.angularDrag = .5f;
            rb.AddForce(Random.onUnitSphere * 20f, ForceMode.Impulse);
            rb.velocity += Vector3.up * 25f;
            rb.AddRelativeTorque(Random.insideUnitSphere * 50f, ForceMode.Impulse);
            gameObject.AddComponent<DetectCollision>();
        }
    }
}
