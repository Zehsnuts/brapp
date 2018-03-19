using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : MonoBehaviour {

	public Transform content;

	public void Start()
	{
		//transform.GetComponent<ContentAnimation> ().OpenContent ();
	}

	public void ShowCont()
	{
		content.GetComponent<ContentAnimation> ().OpenContent ();
		transform.GetComponent<ContentAnimation> ().CloseContent ();
	}
}
