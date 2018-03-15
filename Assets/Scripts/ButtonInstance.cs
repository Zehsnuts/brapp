using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInstance : MonoBehaviour {

	Vector3 initialPosition;

	public void Awake()
	{
		initialPosition = transform.position;
	}

	public void instantiateButton(GameObject button, string direction)
	{
		transform.position = Vector3.zero;
	}
}
