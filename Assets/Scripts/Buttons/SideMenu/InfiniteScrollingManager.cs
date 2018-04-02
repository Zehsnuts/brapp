using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollingManager : MonoBehaviour 
{
	Transform nextButton;  
	Transform currentButton;  
	Transform previousButton;

	float lastYPosition;

	List<Transform> ButtonList = new List<Transform>();

	void Start()
	{
		lastYPosition = transform.position.y;
	}

	public void PullFirstButtonDown(Transform btn)
	{	
		var btnScript = btn.GetComponent<InfiniteScrollingButton> ();

		InstantiateButton (btn,"");
	}

	public void PullLastButtonUp(Transform btn)
	{		
		var btnScript = btn.GetComponent<InfiniteScrollingButton> ();

		InstantiateButton (btn, "up");
	}

	void InstantiateButton(Transform button, string whereShouldGO)
	{
		currentButton = button;

		button.GetComponent<InfiniteScrollingButton>().Start ();

		var b = Instantiate (currentButton,transform);

		if (whereShouldGO == "up") 
		{
			b.GetComponent<InfiniteScrollingButton> ().nextButton = currentButton;			
			b.SetAsFirstSibling ();
		} 
		else 
		{
			b.GetComponent<InfiniteScrollingButton> ().previousButton = currentButton;
			b.SetAsLastSibling ();
		}
	}
}
