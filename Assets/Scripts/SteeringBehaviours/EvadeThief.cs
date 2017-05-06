using UnityEngine;
using System.Collections;

public class EvadeThief : MonoBehaviour {

	public NormalMove target;
	public PursuitPolice target2;

    public float speed;
	public float rotationSpeed;

	private Vector3 _predictedDirection = Vector3.zero;

	void Update()
	{
        //Calculamos donde va a estar el policia
        Vector3 policeFuturePosition = Vector3.zero;

        if (target)
            policeFuturePosition = target.transform.position + target.transform.forward * target.speed;
        else
            policeFuturePosition = target2.transform.position + target2.transform.forward * target2.speed;

        //Buscamos como posicion a donde queremos ir, la direccion contraria a la que va con respecto a la posicion que va a estar
        _predictedDirection = -(policeFuturePosition - transform.position);
		//Cambiamos la direccion
		transform.forward = Vector3.Lerp (transform.forward, _predictedDirection, rotationSpeed * Time.deltaTime);
		//Vamos hacia la direccion
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		//Dibujamos el foward del ladron
		Gizmos.DrawLine (transform.position, transform.position + transform.forward * speed);
		Gizmos.color = Color.white;
		//Dibujamos hacia donde deberia ir el personaje
		Gizmos.DrawLine(transform.position, transform.position + _predictedDirection.normalized);
	}
}
