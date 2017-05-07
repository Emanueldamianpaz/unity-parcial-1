using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State {

	private float speed;
	private float rotationSpeed;

	private NPC npc;
	private Vector3 _dirToGo;


	public WanderState(StateMachine sm, NPC npc) : base(sm)
	{
		this.npc = npc;
		this.speed = npc.getSpeed();
		this.rotationSpeed = npc.getRotationSpeed();
	}

	public override void Awake()
	{
		Debug.Log("-- State Wander open");
		Debug.Log ("Target: " + npc.getTypeTarget());

		base.Awake();
	}

	public override void Execute()
	{
		base.Execute ();

		speed = npc.getSpeed();
		rotationSpeed = npc.getRotationSpeed ();
		Vector3 aux = npc.transform.forward;
		GameObject target = npc.getTarget ();
			
		npc.transform.position += SeekPolice.Seek(npc,target, speed, rotationSpeed,aux );
	}

	public override void Sleep()
	{
		Debug.Log("-- State Flee close");
		base.Sleep();
	}

}
