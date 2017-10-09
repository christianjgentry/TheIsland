using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

    public float speed = 75f;
    private float _speed;
    public Transform head;
    public Transform rig;
    Rigidbody rb;
    Vector3 moveDir = Vector3.zero;
    Vector3 startPos;

    public GameObject rightController;
    public GameObject leftController;
    VRTK_ControllerEvents right;
    VRTK_ControllerEvents left;
    private bool trigger = false;
    // VR mode = true vs Debug mode = false
    private bool mode = true;

    private void Start()
    {
        startPos = transform.position;
        right = rightController.GetComponent<VRTK_ControllerEvents>();
        left = leftController.GetComponent<VRTK_ControllerEvents>();
        //head = GameObject.Find("Camera (eye)").transform;
        rb = GameObject.Find("[CameraRig]").GetComponent<Rigidbody>();
        _speed = 0f;

    }

    private void Update()
    {
        if (right.startMenuPressed)
            ResetScene();

    }


    private void FixedUpdate()
    {
        moveDir = head.forward;

        if (trigger)
        {
            if (_speed < speed)
            {
                _speed += speed / 175f;
            }
            if (mode == true)
            {
                moveDir.y = 0f;
            }

            rig.Translate(moveDir * _speed * Time.fixedDeltaTime);
        }

        else if(_speed > 0)
        {
            _speed -= speed / 20;
        }

        else if (_speed < 0)
        {
            _speed = 0;
        }

    }

    public void TriggerPressed()
    {
        trigger = true;
    }

    public void TriggerReleased()
    {
        trigger = false;
    }

    public void ModeSwitch()
    {
        Debug.Log("Switch");
        mode = !mode;
        if (mode == false)
        {
            rb.useGravity = false;
        }
        else
            rb.useGravity = true;
    }

    public void ResetScene()
    {
        Debug.Log("Restarting");
        transform.position = startPos;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
