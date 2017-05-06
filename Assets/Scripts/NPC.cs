using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    StateMachine _sm;

	void Start () {
      /*  _sm = new StateMachine();
        _sm.AddState(new StateIdleNPC(_sm, this));
        _sm.AddState(new StateJumpNPC(_sm, this));*/
    }
	
	void Update () {
     /* _sm.Update();
        if (Input.GetKeyDown(KeyCode.Q))
            _sm.SetState<StateIdleNPC>();
        else if (Input.GetKeyDown(KeyCode.W))
            _sm.SetState<StateJumpNPC>();
       */
	}
}
