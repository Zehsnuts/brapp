using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMenuButton : MonoBehaviour {

	public GameObject content;


	public void OnClick () 
	{
		content.GetComponent<ContentAnimation> ().OpenContent ();
	}
}
