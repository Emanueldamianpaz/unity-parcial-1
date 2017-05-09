using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


    public float speed;



    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed ;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed ;
        }

    }

}
