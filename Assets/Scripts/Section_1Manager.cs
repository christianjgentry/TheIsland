using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Section_1Manager : MonoBehaviour {

    AsyncOperation async;
    public Vector3 startPos = Vector3.zero;
	// Use this for initialization
	void Start () {

        async = SceneManager.LoadSceneAsync("Section_1");
        async.allowSceneActivation = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SceneChange(string scene_to_load)
    { 
        SceneManager.LoadScene(scene_to_load);
    }
}
