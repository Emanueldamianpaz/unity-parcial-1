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

    void Start() {
        _sm = new StateMachine();
        _sm.AddState(new FleeState(_sm, this));
        _sm.AddState(new WanderState(_sm, this));

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("waypoints");
        foreach (GameObject waypoint in waypoints){
            listWaypoints.Add(waypoint);
        }


        GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombies");
        foreach (GameObject zombie in zombies){
            listZombies.Add(zombie);
        }

    }

    void Update () {
		_sm.Update ();

		if (base.target == null || (base.getTarget ().transform.position - base.transform.position).magnitude < 2) {
			base.target = GetNextTarget();
		}
        Debug.Log("UPDATE:"+listZombies[1]);
		GameObject zombieDanger = null;
		foreach (var item in listZombies) {
			Debug.Log ("ZombieTarget:"+ item);

			if (Vector3.Distance (item.transform.position, base.transform.position) < 15){
				zombieDanger = item;
			}
		}

		// Setting states

		if (zombieDanger != null) {
			base.target=zombieDanger;
			_sm.SetState<FleeState>();
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
