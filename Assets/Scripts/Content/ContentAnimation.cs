using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentAnimation : MonoBehaviour {

	private Animator _animator;

	void Awake()
	{
		if (_animator == null)
			transform.GetComponent<Animator> ();
	}

	public void PlayAnimator()
	{
		//_animator.Play ();
	}
}
