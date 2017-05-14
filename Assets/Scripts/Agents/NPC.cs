using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

	protected float speed;
	protected float rotationSpeed;
	protected string typeTarget;
	protected GameObject target;
    protected float pushedTime;

    public float getSpeed(){
		return speed;	
	}

    public float getPushedTime()
    {
        return pushedTime;
    }

    public void setPushedTime(float pushedTime)
    {
        this.pushedTime = pushedTime;
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
