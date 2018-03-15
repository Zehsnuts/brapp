using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScalling : MonoBehaviour {

	public Transform parent;
	Transform image;

	void Start () 
	{
		if (image == null)
			image = transform.Find ("Image").transform;
		
		float dist = Vector2.Distance(parent.transform.position, transform.position);

		image.localScale = new Vector3(1 - (dist/100),1 - (dist/100),1 - (dist/100));
	}
	
	// Update is called once per frame
	void Update () 
	{
		float dist = Vector2.Distance(parent.transform.position, transform.position);
		Vector3 dif = new Vector3 ((1 - (dist/1000)), 1 - (dist/1000), 1 - (dist/1000));
		if (dif.y >= 0.5f)
			image.localScale = dif;

		if (dif.y < 0.5f)
			image.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			

	}

	public void assingButtonAsTarget()
	{
		FindObjectOfType<ButtonSnap> ().assignTargetButton (transform);
	}
}
