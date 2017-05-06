using UnityEngine;
using System.Collections;

public class StateIdleNPC : HumanState
{
	public StateIdleNPC(StateMachine sm, HumanBehaviour n) : base(sm, n)
    {
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
