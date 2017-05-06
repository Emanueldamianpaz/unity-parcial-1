using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateFlee : State{
	
	private List<GameObject> listTargets = new List<GameObject>();
	private float speed=5f;
	private float rotationSpeed=0.3f;
	private MonoBehaviour mono;
	private Vector3 _dirToGo;

	public StateFlee(StateMachine sm, MonoBehaviour mono) : base(sm)
	{
		this.mono = mono;
	}

	public override void Awake()
	{
		Debug.Log("-- State Flee open");
		GameObject[] arrayTarget = GameObject.FindGameObjectsWithTag("zombies");

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
			_dirToGo = -(target.transform.position - mono.transform.position);
			mono.transform.forward = Vector3.Lerp (mono.transform.forward, _dirToGo, rotationSpeed * Time.deltaTime);
			mono.transform.position += mono.transform.forward * speed * Time.deltaTime;
		}
	}

	public override void Sleep()
	{
		Debug.Log("-- State Flee close");
		base.Sleep();
	}
}
