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
        this.listHumans = new List<GameObject>();
    }

    void Start()
    {
        _sm = new StateMachine();
        _sm.AddState(new FleeState(_sm, this));
        _sm.AddState(new WanderState(_sm, this));

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

        /* 
         * Punto extra
         *    GameObject zombieDanger = null;
          foreach (GameObject item in listHumans)
          {
              if (Vector3.Distance(item.transform.position, base.transform.position) < 15)
              {
                  zombieDanger = item;
              }
          }

          // Setting states

          if (zombieDanger != null)
          {
              base.target = zombieDanger;
              _sm.SetState<FleeState>();
          }
          else
          {
              _sm.SetState<WanderState>();
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
