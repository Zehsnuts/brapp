using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollingManager : MonoBehaviour 
{
	Transform nextButton;  
	Transform currentButton;  
	Transform previousButton;

	float lastYPosition;

	List<Transform> topButtonList = new List<Transform>();
	List<Transform> bottomButtonList = new List<Transform>();

	public void PullFirstButtonDown(Transform btn)
	{			

		var btnScript = btn.GetComponent<InfiniteScrollingButton> ();

		if (btn == currentButton || btnScript.nextButton == btn)
			return;

		currentButton = btn;

		var b = Instantiate (currentButton,transform);
		b.SetAsLastSibling ();

	}

	public void PullLastButtonUp(Transform btn)
	{		
		lastYPosition = transform.position.y;
		var btnScript = btn.GetComponent<InfiniteScrollingButton> ();

		if (btn == currentButton || btnScript.previousButton == btn)
			return;

		currentButton = btn;

		lastYPosition = transform.position.y;

		btnScript.nextButton.GetComponent<InfiniteScrollingButton> ().Awake ();
		btnScript.previousButton.GetComponent<InfiniteScrollingButton> ().Awake ();

		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);

		var b = Instantiate (currentButton,transform);
		b.SetAsFirstSibling ();


	}
}
