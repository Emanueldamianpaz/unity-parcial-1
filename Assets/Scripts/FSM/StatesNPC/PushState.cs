using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushState : State
{

    private float speed;
    private NPC npc;
    private GameObject target;

    public PushState(StateMachine sm, NPC npc) : base(sm)
    {
        this.npc = npc;
        this.speed = npc.getSpeed();
    }

    public override void Awake()
    {
        // Debug.Log("-- State Push open");
        target = npc.getTarget();

        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
        npc.setPushedTime(npc.getPushedTime()-Time.deltaTime);
        if(npc.getPushedTime() <= 0){
			    npc.GetComponent<Rigidbody>().AddForce(Vector3.forward * - 10);
                npc.setPushedTime(1);

        }

        
    }

    public override void Sleep()
    {
        //	Debug.Log("-- State Push close");
        base.Sleep();
		npc.setPushedTime(0);

    }
}
