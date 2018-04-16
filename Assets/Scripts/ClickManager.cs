using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour {

    Vector3 startPosition;
    Vector3 endPosition;
	
	
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

	void Update () 
    {
        //Check if the left Mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if(result.gameObject.name == "zoomableImage")
                    result.gameObject.transform.GetComponent<ContentZoom>().ClickOnImage();

                if (result.gameObject.name == "SideMenuButtons" || result.gameObject.name == "SideMenu")
                    FindObjectOfType<SideMenuManager>().StopMenuScrolling();

                //Debug.Log("Hit " + result.gameObject.name);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(startPosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(endPosition);
            if (startPosition != endPosition && startPosition != Vector3.zero && endPosition != Vector3.zero)
            {
                float deltaX = endPosition.x - startPosition.x;

                if (deltaX > 0.5)
                    FindObjectOfType<SideMenuManager>().OpenSideMenu();
                if (deltaX < -0.5)
                    FindObjectOfType<SideMenuManager>().CloseSideMenu();

                

                startPosition = endPosition = Vector3.zero;
            }
        }

       
	}
}
