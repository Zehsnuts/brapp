﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScalling : MonoBehaviour {

	public Transform parent;
	Transform image;

	void Start () 
	{
		if (image == null)
			image = transform.Find ("Image").transform;
		
		ChangeSize ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangeSize ();
	}

	void ChangeSize()
	{
		float dist = Vector2.Distance(parent.transform.position, transform.position);
		Vector3 dif = new Vector3 ((1 - (dist/1000)), 1 - (dist/1000), 1 - (dist/1000));
		if (dif.y >= 0.3f)
			image.localScale = dif;

		if (dif.y < 0.3f)
			image.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
	}

	public void assingButtonAsTarget()
	{
		FindObjectOfType<ButtonSnap> ().assignTargetButton (transform);
	}
}
