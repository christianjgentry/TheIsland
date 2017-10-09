using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {

    Vector3 moveDir;
    public float speed = 75f;
    private float _speed;

    private void FixedUpdate()
    {
        moveDir = transform.forward;

        if (Input.GetKey(KeyCode.Space))
        {
            if (_speed < speed)
            {
                _speed += speed / 75;
            }

            transform.Translate(moveDir * _speed * Time.fixedDeltaTime);
        }

        else if (_speed > 0)
        {
            _speed -= speed / 20;
        }

        else if(_speed < 0)
        {
            _speed = 0;
        }

        Debug.Log(_speed);
    }
}
