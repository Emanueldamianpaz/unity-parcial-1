using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushState : State
{

    private float speed;
    private float pushedTime;
    private NPC npc;
    private GameObject target;

    public PushState(StateMachine sm, NPC npc) : base(sm)
    {
        this.npc = npc;
        this.speed = npc.getSpeed();
        this.pushedTime = npc.getPushedTime();
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
        pushedTime -= Time.deltaTime;
        if(pushedTime <=0){
                npc.GetComponent<Rigidbody>().AddForce(PushNpc.Push(speed));
                pushedTime = 5;

        }

        
    }

    public override void Sleep()
    {
        //	Debug.Log("-- State Push close");
        base.Sleep();
        pushedTime = 0;
    }
}
