using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ContentManager : MonoBehaviour 
{
    public List<Transform> _contents;

	private Transform _currentContent;

	public void Start()
	{
        foreach (Transform child in transform)
        {
            _contents.Add(child);
        }
    }

	public void ChangeContent(string btnName)
	{
		string[] nm = btnName.Split ("_"[0]);
			ContentAnimation (nm[2]);
	}

	public void ContentAnimation(string name)
	{
        Transform content = _contents.Where(obj => obj.name == name).SingleOrDefault();

			
        Debug.Log (content.name);

		//if (content == _currentContent)
			//return;

		if (_currentContent != null)
			_currentContent.GetComponent<ContentAnimation> ().CloseContent ();

		_currentContent = content;

		_currentContent.GetComponent<ContentAnimation> ().OpenContent ();
	}

}
