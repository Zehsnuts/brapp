using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuButtonUnit : MonoBehaviour {

	public float initialDistance;
	public float distanceFromTarget;

	public Transform previousButton;
	public Transform nextButton;  
	public Transform menuCenter;

	public void Start()
	{
		initialDistance = Vector3.Distance (transform.position, menuCenter.position);
	}

	public void Update ()
	{
		distanceFromTarget = Vector3.Distance (transform.position, menuCenter.position);
	}
}
