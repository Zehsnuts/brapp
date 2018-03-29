using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollingButton : MonoBehaviour 
{
	public Transform previousButton;
	public Transform nextButton;  
	public Transform menuCenter;

	Vector3 initialPosition;

	bool isButtonBeingProcessed = false;

	public void Awake()
	{
		initialPosition = transform.position;
	}

	//Update para ver distancia entre o botão e o "menuCenter". Pode virar uma função em classe mais especifica para botão já que essa distancia é usada na classe ButtonScalling
	void Update()
	{
		DistanceCheck ();
	}

	void DistanceCheck()
	{
		var dist = Vector3.Distance (transform.position, initialPosition);


		if(dist>1900 && isButtonBeingProcessed == false)
		{
			isButtonBeingProcessed = true;

			if (transform.position.y > menuCenter.position.y)
				FindObjectOfType<InfiniteScrollingManager> ().PullFirstButtonDown (transform);
			else if(transform.position.y < menuCenter.position.y)
				FindObjectOfType<InfiniteScrollingManager> ().PullLastButtonUp (transform);
		}

		//if (dist > 2500 && isButtonBeingProcessed)
			//Destroy (gameObject);

		if(dist < 900 && isButtonBeingProcessed)
			isButtonBeingProcessed = false;
	}
}
