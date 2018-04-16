using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMenuManager : MonoBehaviour {

	public Transform sideMenu;
    public Transform menuAnimator;
	private Animator _sideMenuAnimator;

    public bool _isMenuOpen;

    private bool _scrollThroughMenu;

	void Start()
	{
        _sideMenuAnimator = menuAnimator.GetComponent<Animator> ();
        _scrollThroughMenu = false;
        _isMenuOpen = true;

        //StartCoroutine(WaitBeforeScrollingMenu());
	}

	private void Update()
	{
        if (!_scrollThroughMenu)
            return;
	}

    public void OpenOrCloseMenu()
    {
        if (!_isMenuOpen)
            OpenSideMenuWithIdle();
        else
            CloseSideMenu();
    }


	public void OpenSideMenu()
	{
        if (_isMenuOpen)
            return;
        
        _isMenuOpen = true;
		_sideMenuAnimator.Play ("OpenSideMenu");       

        //StartCoroutine(WaitingToCloseMenu());
	}

    public void OpenSideMenuWithIdle()
    {
        _sideMenuAnimator.Play ("OpenSideMenu");   
        //StartCoroutine(WaitBeforeScrollingMenu());
    }

    //
	public void CloseSideMenu()
	{
        if (!_isMenuOpen)
            return;

		_sideMenuAnimator.Play ("CloseSideMenu");

        _isMenuOpen = false;

        StopMenuScrolling();

        //StopCoroutine(WaitingToCloseMenu());
	}

    IEnumerator WaitingToCloseMenu()
    {
        yield return new WaitForSeconds(5);
        CloseSideMenu();
    }

    public void StopMenuScrolling()
    {
        FindObjectOfType<IdleScrolling>().StopAutoScroll();
    }

    //Counter to begin scrolling automatically through menu
    IEnumerator WaitBeforeScrollingMenu()
    {
        yield return new WaitForSeconds(5);
        _scrollThroughMenu = true;
    }
}
