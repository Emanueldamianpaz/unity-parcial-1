using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : NPC {

	private StateMachine _sm;
	private List<GameObject> listWaypoints = new List<GameObject>();
	private List<GameObject> listZombies = new List<GameObject>();

	public HumanBehaviour(){
		base.speed = 5;
		base.rotationSpeed = 0.3f;



	}


	void Start () {
		_sm = new StateMachine();
		_sm.AddState(new StateIdle(_sm, this));
		_sm.AddState(new FleeState(_sm, this));
		_sm.AddState (new WanderState(_sm, this));

		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("waypoints");
		foreach (GameObject target in waypoints) {
			listWaypoints.Add (target);
		}

		GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombies");
		foreach (GameObject target in zombies) {
			listZombies.Add (target);
		}

	}

	void Update () {
		_sm.Update ();

		Debug.Log ("EL TARGET ES:"+base.target);
		if (base.target == null || (base.getTarget ().transform.position - transform.position).magnitude < 2) {
			base.target = GetNextTarget();
			Debug.Log ("EL TARGET ES:"+base.target);
		}

		GameObject zombieDanger = null;

		foreach (var item in listZombies) {
			Debug.Log ("EL TARGET ES:"+base.target);

			if (Vector3.Distance (item.transform.position, transform.position) < 15){
				zombieDanger = item;
			}
		}

		// Setting states

		if (zombieDanger) {
			base.target=zombieDanger;
			_sm.SetState<FleeState> ();

		} else {
			base.target=GetNextTarget ();
			_sm.SetState<WanderState>();
		}


	}

	private GameObject GetNextTarget()
	{
		int rand = Random.Range(0, listWaypoints.Count);
		return listWaypoints[rand];
	}

}
