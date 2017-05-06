using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {


	float speed=7f;
	float rotationSpeed= 0.3f;

	StateMachine _sm;

	void Start () {

	}

	void Update () {
		_sm.Update();
	
	}
}
