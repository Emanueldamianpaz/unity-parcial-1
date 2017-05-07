using UnityEngine;
using System.Collections;

public static class FleeThief {

    public static Vector3 Flee(NPC npc, GameObject target, float speed, float rotationSpeed, Vector3 _dirToGo)
	{
		_dirToGo = -(target.transform.position - npc.transform.position);
        npc.transform.forward = Vector3.Lerp (npc.transform.forward, _dirToGo, rotationSpeed * Time.deltaTime);
        return (npc.transform.forward * speed * Time.deltaTime);
    }

}
