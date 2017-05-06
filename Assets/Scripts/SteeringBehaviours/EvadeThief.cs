using UnityEngine;
using System.Collections;


public class EvadeThief : MonoBehaviour {


	public void Evade(NormalMove target, PursuitPolice target2, float speed, float rotationSpeed){

		Vector3 _predictedDirection = Vector3.zero;
        Vector3 policeFuturePosition = Vector3.zero;

        if (target)
            policeFuturePosition = target.transform.position + target.transform.forward * target.speed;
        else
            policeFuturePosition = target2.transform.position + target2.transform.forward * target2.speed;

        _predictedDirection = -(policeFuturePosition - transform.position);
		transform.forward = Vector3.Lerp (transform.forward, _predictedDirection, rotationSpeed * Time.deltaTime);
		transform.position += transform.forward * speed * Time.deltaTime;
	}

}
