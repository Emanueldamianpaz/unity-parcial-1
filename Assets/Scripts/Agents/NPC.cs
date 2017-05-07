using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	protected float speed;
	protected float rotationSpeed;
	protected string typeTarget;
	protected GameObject target;


	public float getSpeed(){
		return speed;	
	}

	public float getRotationSpeed(){
		return rotationSpeed;	
	}

	public string getTypeTarget(){
		return typeTarget;
	}

	public GameObject getTarget(){
		return target;
	}

	public void setTarget(GameObject targetFinal){
		target = targetFinal;
	}
}
