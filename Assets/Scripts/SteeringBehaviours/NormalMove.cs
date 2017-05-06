using UnityEngine;
using System.Collections;

public class NormalMove : MonoBehaviour {

    public float speed;

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

}
