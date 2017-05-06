using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateFlee : State{
	
	private List<GameObject> listTargets = new List<GameObject>();
	private float speed;
	private float rotationSpeed;

	private NPC npc;
	private Vector3 _dirToGo;

	public StateFlee(StateMachine sm, NPC npc) : base(sm)
	{
		this.npc = npc;
		this.speed = npc.getSpeed();
		this.rotationSpeed = npc.getRotationSpeed();
	}

	public override void Awake()
	{
		Debug.Log("-- State Flee open");
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

		foreach (GameObject target in listTargets) {
			_dirToGo = -(target.transform.position - npc.transform.position);
			npc.transform.forward = Vector3.Lerp (npc.transform.forward, _dirToGo, rotationSpeed * Time.deltaTime);
			npc.transform.position += npc.transform.forward * speed * Time.deltaTime;
		}
	}

	public override void Sleep()
	{
		Debug.Log("-- State Flee close");
		base.Sleep();
	}
}
