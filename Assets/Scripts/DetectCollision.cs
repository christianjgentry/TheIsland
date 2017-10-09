using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

    private spawnChutes spawnScript;

    private void Start()
    {
        spawnScript = GameObject.Find("ChuteSpawn").GetComponent<spawnChutes>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        spawnScript.spawn();
        Destroy(GetComponent<Rigidbody>());
    }



}
