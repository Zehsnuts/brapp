using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour 
{
	public enum contentList
	{
		None, PDF
	}

	public List<Transform> contents;
	private contentList _currentContent;

	void Awake()
	{
		foreach(Transform t in contents)
			t.gameObject.SetActive(false);
	}

	void Start()
	{
		_currentContent = contentList.None;
	}

	public void ChangeContent(string btnName)
	{
		string[] nm = btnName.Split ("_"[0]);
			ContentAnimation (nm[1]);
	}

	public void ContentAnimation(string name)
	{
		if (name == _currentContent.ToString ())
			return;

		//transform.Find ("btn_" + _currentContent.ToString ()).gameObject.SetActive(false);
		transform.Find (name).gameObject.SetActive (true);


	}

}
