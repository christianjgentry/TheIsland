using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneOnTouch : MonoBehaviour {

    public string scene_to_load;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "GameController")
        {
            GameObject go = GameObject.Find("GameManager");
            go.GetComponent<Section_1Manager>().SceneChange(scene_to_load);
        }
    }
}
