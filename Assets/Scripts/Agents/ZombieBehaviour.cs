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
		} 

		

        _sm.Update();

    }


    private GameObject GetNextTarget() { 

	   if(target){

            List<GameObject> listHumansOther = listHumans ;
            listHumansOther.Remove(target);

            foreach (GameObject item in listHumansOther){
                var distance=(target.transform.position - item.transform.position);
                if(distance.magnitude <= 20  && (Random.Range(0, 100)) >= 50){
                        _sm.SetState<PushState>();
                        base.pushedTime = 0; 
                    };
                 };
                  
        
	        Instantiate(this, target.transform.position, Quaternion.identity);
            listHumans.Remove(target);
            Destroy(target.gameObject);
        };
        

        int rand = Random.Range(0, listHumans.Count);
        return listHumans[rand];
    }


}
