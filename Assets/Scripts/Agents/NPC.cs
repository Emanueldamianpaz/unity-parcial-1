using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	protected float speed;
	protected float rotationSpeed;
	protected string typeTarget;

	public float getSpeed(){
		return speed;	
	}

	public float getRotationSpeed(){
		return rotationSpeed;	
	}

	public string getTypeTarget(){
		return typeTarget;
	}
}
