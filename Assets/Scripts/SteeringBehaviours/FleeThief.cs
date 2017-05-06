using UnityEngine;
using System.Collections;

public class FleeThief : MonoBehaviour {
	
	public void Flee(GameObject target, float speed, float rotationSpeed, Vector3 _dirToGo)
	{
		_dirToGo = -(target.transform.position - transform.position);
		transform.forward = Vector3.Lerp (transform.forward, _dirToGo, rotationSpeed * Time.deltaTime);
		transform.position += transform.forward * speed * Time.deltaTime;
	}

}
