using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State {

	private List<GameObject> listTargets = new List<GameObject>();
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
		GameObject[] arrayTarget = GameObject.FindGameObjectsWithTag(npc.getTypeTarget());


		// Condicion de mover
		foreach (GameObject target in arrayTarget) {
			listTargets.Add (target);
		}

		base.Awake();
	}

	public override void Execute()
	{
		base.Execute ();
		Debug.Log ("Begins flee");

//		foreach (GameObject target in listTargets) {
		GameObject target = GetNextTarget();

		speed = npc.getSpeed();
		rotationSpeed = npc.getRotationSpeed ();
		Vector3 aux = npc.transform.forward;
		npc.transform.position += SeekPolice.Seek(npc,target, speed, rotationSpeed,aux );
//		}
	}

	public override void Sleep()
	{
		Debug.Log("-- State Flee close");
		base.Sleep();
	}

	GameObject GetNextTarget()
	{
		int rand = Random.Range(0, listTargets.Count);
		return listTargets[rand];
	}
}
