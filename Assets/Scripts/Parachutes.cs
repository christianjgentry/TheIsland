using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachutes : MonoBehaviour {

    [SerializeField]
    private Transform parent;
    Vector3 spawnPoint;
    Vector3 movePoint;
    Transform chute;
    public float speed = 10f;
    public float rotateSpeed = .5f;
    public float closeDistance = 35f;
    [SerializeField]
    public float radius;
    public float height;

    void Start () {
        chute = gameObject.transform;
        spawnPoint = parent.transform.position + new Vector3(Random.onUnitSphere.x * radius, Mathf.Abs(Random.onUnitSphere.y) * height, Random.onUnitSphere.z * radius);
        chute.position = spawnPoint;
        changeMovePoint();
		
	}
	
	// Update is called once per frame
	void Update () {

        // Checks if parachute is close to its target destination
        if (IsClose(chute.position, movePoint, closeDistance))
        {
            changeMovePoint();
        }
            // Moves chute towards the target destination
            chute.position = Vector3.MoveTowards(chute.position, movePoint, speed * Time.deltaTime);
            // Finds the vector from chute position to target destination
            Vector3 targetDir = movePoint - chute.position;
            // Get vector to rotate towards to create slow interpolation.
            Vector3 newDir = Vector3.RotateTowards(chute.forward, -targetDir, rotateSpeed * Time.deltaTime, 0f);
            // Actually rotates the chute
            chute.rotation = Quaternion.LookRotation(newDir);
	}

    void changeMovePoint()
    {
        movePoint = parent.transform.position + new Vector3(Random.onUnitSphere.x * radius, Mathf.Abs(Random.onUnitSphere.y) * height, Random.onUnitSphere.z * radius);
        //movePoint = parent.position + topHalf;
    }


    bool IsClose(Vector3 position, Vector3 target, float isCloseDistance)
    {
        if (Mathf.Abs(Vector3.Distance(position, target)) <= isCloseDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
