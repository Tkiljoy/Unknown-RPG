using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGrid : MonoBehaviour
{

	public Transform target; //this will be your player
	public Vector2 size; //room size in unity units
	public float speed; //linear smooting between 0 and 1

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = new Vector3(Mathf.RoundToInt(target.position.x / size.x) * size.x, Mathf.RoundToInt(target.position.y / size.y) * size.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, pos, speed);
	}
}