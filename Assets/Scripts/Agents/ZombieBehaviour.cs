using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : NPC {


    private StateMachine _sm;
    private List<GameObject> listHumans;
    private bool dangerZombie;

    public ZombieBehaviour()
    {
        base.speed = 7;
        base.rotationSpeed = 0.3f;
        base.pushedTime = 0;
        this.listHumans = new List<GameObject>();
        this.dangerZombie=false;
    }

    void Start()
    {
        _sm = new StateMachine();
        _sm.AddState(new WanderState(_sm, this));
        _sm.AddState(new PushState(_sm, this));

        GameObject[] humans = GameObject.FindGameObjectsWithTag("humans");
        foreach (GameObject human in humans)
        {
            listHumans.Add(human);
        }
    }

    void Update()
    {


		if (base.target == null || (base.getTarget ().transform.position - base.transform.position).magnitude <= 2) {
			
			base.target = GetNextTarget ();
			_sm.SetState<WanderState> ();
		} else {
			Debug.Log(base.target);
			foreach (GameObject item in listHumans){
				if((base.target.transform.position - item.transform.position).magnitude <= 10){
					Debug.Log ("siempre entro aca?");
					dangerZombie=true;
				}
			}

		
		};

        _sm.Update();

    }


    private GameObject GetNextTarget() { 

	
		if(dangerZombie && (Random.Range(0, 100)) >= 50){
			_sm.SetState<PushState>();
			base.pushedTime = 0; 
		}else{
            Instantiate(this, target.transform.position, Quaternion.identity);
            listHumans.Remove(target);
            Destroy(target.gameObject);
        }

        int rand = Random.Range(0, listHumans.Count);
        return listHumans[rand];
    }


}
