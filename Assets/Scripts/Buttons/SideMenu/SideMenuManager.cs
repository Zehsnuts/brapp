using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuManager : MonoBehaviour {

	private bool _isSideMenuOpen;
	public Transform sideMenu;
	private Animator _sideMenuAnimator;

	void Start()
	{
		_isSideMenuOpen = true;

		_sideMenuAnimator = sideMenu.GetComponent<Animator> ();
	}


	public void OpenSideMenu()
	{
		_sideMenuAnimator.Play ("OpenSideMenu");

	}

	public void CloseSideMenu()
	{
		_sideMenuAnimator.Play ("CloseSideMenu");
	}
}
