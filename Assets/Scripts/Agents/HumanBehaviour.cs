using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : NPC {

	private StateMachine _sm;

	public HumanBehaviour(){
		base.speed = 5f;
		base.rotationSpeed = 0.3f;
		base.typeTarget = "zombies";
	}


	void Start () {
		_sm = new StateMachine();
		_sm.AddState(new StateIdle(_sm, this));
        _sm.AddState(new StateFlee(_sm, this));

	}

	void Update () {
	 _sm.Update();
        if (Input.GetKeyDown(KeyCode.Q))
            _sm.SetState<StateIdle>();
        else if (Input.GetKeyDown(KeyCode.W))
			_sm.SetState<StateFlee>();
       
	}


}
