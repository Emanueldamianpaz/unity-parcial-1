using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WanderState : State
{

    private float speed;
    private float rotationSpeed;

    private NPC npc;
    private GameObject target;

    public WanderState(StateMachine sm, NPC npc) : base(sm)
    {
        this.npc = npc;
        this.speed = npc.getSpeed();
        this.rotationSpeed = npc.getRotationSpeed();
    }

    public override void Awake()
    {
        target = npc.getTarget();
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
        Vector3 aux = npc.transform.forward;

        npc.transform.position += SeekPolice.Seek(npc, target, speed, rotationSpeed, aux);
    }

    public override void Sleep()
    {
        base.Sleep();
    }

}
