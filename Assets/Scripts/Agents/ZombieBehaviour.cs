using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : NPC {


    private StateMachine _sm;
    private List<GameObject> listHumans;


    public ZombieBehaviour()
    {
        base.speed = 7;
        base.rotationSpeed = 0.3f;
        base.pushedTime = 2;
        this.listHumans = new List<GameObject>();
    }

    void Start()
    {
        _sm = new StateMachine();
        _sm.AddState(new FleeState(_sm, this));
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



        if (base.target == null || (base.getTarget().transform.position - base.transform.position).magnitude <= 2)
        {
            base.target = GetNextTarget();
            _sm.SetState<WanderState>();
        }

     /*   foreach (GameObject item in listHumans)
        {
            //double r = Random.Range(0, 1);
            double r = 0.2;
            if (r <= 0.5 && (base.getTarget().transform.position - item.transform.position).magnitude < 4)
            {
                _sm.SetState<PushState>();
                target = null;
                break;

            }
        }
        */




        _sm.Update();

    }


    private GameObject GetNextTarget() { 
        if (target)
        {
            Instantiate(this, target.transform.position, Quaternion.identity);
            listHumans.Remove(target);
            Destroy(target.gameObject);

   
        }

        int rand = Random.Range(0, listHumans.Count);
        return listHumans[rand];
    }


}
