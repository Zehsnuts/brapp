using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentAnimation : MonoBehaviour {

	private Animator _animator;

	void Start()
	{
		if (_animator == null)
			transform.GetComponent<Animator> ();
	}

	void OnEnabled()
	{
		if (_animator == null)
			transform.GetComponent<Animator> ();
	}

	public void OpenContent()
	{
		_animator.Play ("OpenContent");
	}

	public void CloseContent()
	{
		_animator.Play ("CloseContent");
	}
}
