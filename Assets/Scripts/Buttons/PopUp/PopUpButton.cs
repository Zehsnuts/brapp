using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour {

	public GameObject popupScreen;

	// Use this for initialization
	void Start () 
	{
		popupScreen.SetActive (false);
	}
	
	public void OpenPopUp()
	{
		popupScreen.SetActive (true);
	}

	public void ClosePopUp()
	{
		popupScreen.SetActive (false);
	}
}
