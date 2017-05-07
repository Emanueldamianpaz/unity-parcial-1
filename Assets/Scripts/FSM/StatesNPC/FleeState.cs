using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FleeState : State
{

    private float speed;
    private float rotationSpeed;

    private NPC npc;
    private GameObject target;

    public FleeState(StateMachine sm, NPC npc) : base(sm)
    {
        this.npc = npc;
        this.speed = npc.getSpeed();
        this.rotationSpeed = npc.getRotationSpeed();
    }

    public override void Awake()
    {
        // Debug.Log("-- State Flee open");
        target = npc.getTarget();

        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
        Vector3 aux = npc.transform.forward;

        npc.transform.position += FleeThief.Flee(npc, target, speed, rotationSpeed, aux);
    }

    public override void Sleep()
    {
        //	Debug.Log("-- State Flee close");
        base.Sleep();
    }
}
