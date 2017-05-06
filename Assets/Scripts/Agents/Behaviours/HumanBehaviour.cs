using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : MonoBehaviour {

	float speed=5f;
	float rotationSpeed= 0.3f;

	StateMachine _sm;


	void Start () {
		_sm = new StateMachine();
        _sm.AddState(new StateIdleNPC(_sm, this));
        
		_sm.AddState(new StateFlee(_sm, this));

	}

	void Update () {
	 _sm.Update();
        if (Input.GetKeyDown(KeyCode.Q))
            _sm.SetState<StateIdleNPC>();
        else if (Input.GetKeyDown(KeyCode.W))
			_sm.SetState<StateFlee>();
       
	}

	public float getSpeed(){
		return speed;	
	}

}
