using System.Collections.Generic;
using UnityEngine;

public class HumanBehaviour : NPC {

	private StateMachine _sm;
    private List<GameObject> listWaypoints;
    private List<GameObject> listZombies;


    public HumanBehaviour(){
		base.speed = 5;
		base.rotationSpeed = 0.3f;
        this.listWaypoints = new List<GameObject>();
        this.listZombies = new List<GameObject>();
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
        foreach (GameObject zm in zombies){
            listZombies.Add(zm);
        }
        

    }

    void Update () {
		


        if (base.target == null || (base.getTarget ().transform.position - base.transform.position).magnitude < 2) {
			base.target = GetNextTarget();
		}
		GameObject zombieDanger = null;
		foreach (GameObject item in listZombies) {
			Debug.Log ("ZombieTarget:"+ item);

			if (Vector3.Distance (item.transform.position, base.transform.position) < 20){
				zombieDanger = item;
			}
		}

		// Setting states

		if (zombieDanger != null) {
			base.target=zombieDanger;
			_sm.SetState<FleeState>();
        } else {
		   _sm.SetState<WanderState>();
		}

        _sm.Update();

    }

	private GameObject GetNextTarget()
	{
		int rand = Random.Range(0, listWaypoints.Count);
		return listWaypoints[rand];
	}

}
