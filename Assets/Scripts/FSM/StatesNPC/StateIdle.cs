using UnityEngine;
using System.Collections;

public class StateIdle : State
{
	public StateIdle(StateMachine sm, NPC npc) : base(sm)    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Idle");
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
        
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Idle");
        base.Sleep();
    }
}
