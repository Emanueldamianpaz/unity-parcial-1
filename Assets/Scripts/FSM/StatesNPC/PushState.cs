using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PushState : State
{

    private float speed;
    private float rotationSpeed;
    private float pushedTime;
    private NPC npc;
    private GameObject target;

    public PushState(StateMachine sm, NPC npc) : base(sm)
    {
        this.npc = npc;
        this.speed = npc.getSpeed();
        this.rotationSpeed = npc.getRotationSpeed();
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
        Vector3 aux = npc.transform.forward;

        npc.transform.position += PushNpc.Push(npc, target, speed, rotationSpeed, aux, pushedTime);
    }

    public override void Sleep()
    {
        //	Debug.Log("-- State Push close");
        base.Sleep();
    }
}
