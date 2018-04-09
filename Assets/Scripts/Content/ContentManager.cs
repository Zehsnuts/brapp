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

	private Transform _currentContent;

	public void ChangeContent(string btnName)
	{
		string[] nm = btnName.Split ("_"[0]);
			ContentAnimation (nm[2]);
	}

	public void ContentAnimation(string name)
	{
		Transform content = transform.Find (name);		
		Debug.Log (name);

		if (content == _currentContent)
			return;

		if (_currentContent != null)
			_currentContent.GetComponent<ContentAnimation> ().CloseContent ();

		_currentContent = content;

		_currentContent.GetComponent<ContentAnimation> ().OpenContent ();
	}

}
