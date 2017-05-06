using UnityEngine;
using System.Collections;

public class SeekPolice : MonoBehaviour {

	public GameObject target;
	public float speed;
	public float rotationSpeed;

	private Vector3 _dirToGo;

	void Update()
	{
		//Calculamos hacia donde deberia estar mirando
		_dirToGo = target.transform.position - transform.position;
		//Vamos modificando el foward hacia la direccion
		transform.forward = Vector3.Lerp (transform.forward, _dirToGo, rotationSpeed * Time.deltaTime);
		//Hacemos que avance hacia adelante
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		//Dibujamos el foward del policia
		Gizmos.DrawLine (transform.position, transform.position + transform.forward * speed);
		Gizmos.color = Color.white;
		//Dibujamos hacia donde deberia estar mirando
		Gizmos.DrawLine (transform.position, transform.position + _dirToGo.normalized * speed);
	}
}
