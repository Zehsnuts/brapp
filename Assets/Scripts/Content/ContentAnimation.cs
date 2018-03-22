using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentAnimation : MonoBehaviour {

	private Animator _animator;
	private Animator _subMenuAnimator;
	private bool _hasSubMenu;
	private bool _isSubMenuOpen;
	public GameObject subMenu;
	public GameObject content;

	void Start()
	{
		if (subMenu != null) 
		{
			_hasSubMenu = true;
			_subMenuAnimator = subMenu.GetComponent<Animator> ();
			_isSubMenuOpen = false;
		}
		else
			_hasSubMenu = false;

		if (_animator == null)
			content.GetComponent<Animator> ();
	}

	void CheckAnimators()
	{
		if (_animator == null)
			_animator = content.GetComponent<Animator> ();

		if (subMenu != null) 
			_subMenuAnimator = subMenu.GetComponent<Animator> ();
	}

	public void OpenContent()
	{
		CheckAnimators ();

		if (_hasSubMenu && !_isSubMenuOpen) 
		{
			_subMenuAnimator.Play ("OpenContent");
			_animator.Play ("CloseContent");
			_isSubMenuOpen = true;
		}
		else 
		{
			if (_hasSubMenu) 
			{
				_subMenuAnimator.Play ("CloseContent");
				_isSubMenuOpen = false;
			}
			
			_animator.Play ("OpenContent");
		}
	}

	public void CloseContent()
	{
		CheckAnimators ();
		if (_hasSubMenu && _isSubMenuOpen) 
		{
			_subMenuAnimator.Play ("CloseContent");
			_isSubMenuOpen = false;
		} 
		else 
		{
			_animator.Play ("CloseContent");
			_isSubMenuOpen = false;
		}
	}
}
