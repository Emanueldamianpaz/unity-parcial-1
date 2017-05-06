using UnityEngine;
using System.Collections;

public class PursuitPolice : MonoBehaviour {

	public NormalMove target;
    public EvadeThief target2;

	public float speed;
	public float timeOfPrediction;
	public float rotationSpeed;

	private Vector3 _predictedPosition = Vector3.zero;

	void Update()
	{
		//Obtenemos la posicion a la que debemos apuntar
        if(target)
		    _predictedPosition = target.transform.position + target.transform.forward * target.speed * timeOfPrediction;
        else
		    _predictedPosition = target2.transform.position + target2.transform.forward * target2.speed * timeOfPrediction;

        //Hacemos que se rote hacia esa direccion
        transform.forward = Vector3.Lerp (transform.forward, _predictedPosition - transform.position, rotationSpeed * Time.deltaTime);

		//Hacemos que avance
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		//Dibujamos el foward del policia
		Gizmos.DrawLine (transform.position, transform.position + transform.forward * speed);
		//Dibujamos la posicion de prediccion
		Gizmos.DrawSphere (_predictedPosition, 0.2f);
	}
}
