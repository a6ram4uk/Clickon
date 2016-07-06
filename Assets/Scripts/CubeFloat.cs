using UnityEngine;
using System.Collections;

public class CubeFloat : MonoBehaviour 
{

	public float speed, tilt;
	private Vector3 target = new Vector3 (0, 1.5f, 0);

	void Update () 
	{
		transform.position = Vector3.MoveTowards (transform.position, target, Time.deltaTime * speed);
		if (transform.position == target && target.y != 0.5f)
			target.y = 0.5f;
		else if (transform.position == target && target.y == 0.5f)
			target.y = 1.5f;

		transform.Rotate (Vector3.up * tilt);
	}
}
