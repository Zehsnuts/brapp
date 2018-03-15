using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTeleport : MonoBehaviour {


	bool checkForUp=true;
	bool checkForDown=true;

	public Transform nextButton;

	void Update () 
	{
		Debug.Log (transform.name+" position:" + transform.position);

		if (transform.position.y >= 1600 && checkForUp) 
		{
			transform.SetAsLastSibling ();
			nextButton.SetAsFirstSibling ();
			FindObjectOfType<ButtonInstance> ().instantiateButton (gameObject, "");
		}

	}
}
