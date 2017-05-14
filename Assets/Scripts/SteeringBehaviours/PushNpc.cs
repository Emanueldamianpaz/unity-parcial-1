using UnityEngine;
using System.Collections;

public static class PushNpc
{

    public static Vector3 Push(NPC npc, GameObject target, float speed, float rotationSpeed, Vector3 _dirToGo, float pushedTime)
    {
    
        

        _dirToGo = (-(target.transform.position - npc.transform.position));
        npc.transform.forward = Vector3.Lerp(npc.transform.forward, _dirToGo, rotationSpeed * Time.deltaTime);
        pushedTime -= Time.deltaTime;
        

        if (pushedTime < 0){
            pushedTime = 3;
        }
        

        return (npc.transform.forward * speed * Time.deltaTime);



    }



}

