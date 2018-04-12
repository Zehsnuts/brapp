using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSnap : MonoBehaviour 
{

	bool shouldMoveToPosition;
	Transform targetButton;
	public Transform menuCenter;

	float initialDistanceButtonToCenter=0;

    private ContentManager _contentManager;

	private void Start()
	{
        _contentManager = FindObjectOfType<ContentManager>();
    }

	public void assignTargetButton(Transform button)
	{
		shouldMoveToPosition = true;
		targetButton = button;

		initialDistanceButtonToCenter = Vector3.Distance(button.position, menuCenter.position);

        _contentManager.ChangeContent (targetButton.name);
		FindObjectOfType<SideMenuManager> ().CloseSideMenu ();
	}

	public float speed = 0f;
	public float ac = 2f;
	public float maxSpeed = 1000f;
	public float minSpeed = 1f;


	void Update()
	{
		if (!shouldMoveToPosition)
			return;

		float distButtonToCenter = Vector3.Distance(targetButton.position, menuCenter.position);

				
		//Debug.Log ("Adding speed: " + speed + ". Accel = " + ac);

		if (targetButton.position.y < menuCenter.position.y )
			transform.position += new Vector3 (0, (speed/2)*Time.deltaTime, 0); 
		else
			transform.position -= new Vector3 (0, (speed/2)*Time.deltaTime, 0); 

		if (speed < maxSpeed && distButtonToCenter > initialDistanceButtonToCenter / 2)
			speed += ac;
		else if (speed > minSpeed && distButtonToCenter < initialDistanceButtonToCenter/2)
			speed -= ac*1.2f;

		//For better precision, change distButtonToCenter < X
		if (distButtonToCenter < 40f) 
		{
			shouldMoveToPosition = false;
			speed = 0;
		}

		//Debug.Log (distButtonToCenter);
		//Debug.Log("Distance to Button: "+ distButtonToCenter +"\n " + initialDistanceButtonToCenter / 2);
	}
		
}
