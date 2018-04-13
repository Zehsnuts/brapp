using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentZoom : MonoBehaviour 
{
    public ScrollRect contentParent;

    public RectTransform contentCapsule;
    Vector3 contentCapsuleNaturalPosition;

    float initialFingersDistance ;
    Vector3 initialScale;
    Vector3 naturalScale;
    Vector3 naturalPosition;

    bool shouldRunTimer;
    float timer;
    bool isZoomed;

    bool canBeZoomed;

	void Start()
	{
        contentCapsuleNaturalPosition = contentCapsule.position;

        naturalScale = transform.localScale;
        isZoomed = false;
        shouldRunTimer = false;
        canBeZoomed = false;
        timer = 0;
	}


    public void ClickOnImage()
    {
        canBeZoomed = true;
    }

    void ZoomInAndOut()
    {
        shouldRunTimer = false;
        timer = 0;

        if (isZoomed)
        {
            transform.localScale = transform.localScale / 1.5f;
            isZoomed = false;
        }
        else
        {
            transform.localScale = initialScale * 1.5f;
            isZoomed = true;
        }
    }

    void ConstrainImageSize()
    {
        if (transform.localScale.x > (1.5f * naturalScale.x) || transform.localScale.y > (1.5f * naturalScale.y))
            transform.localScale = 1.5f * naturalScale;



        if (transform.localScale.x < naturalScale.x || transform.localScale.y < naturalScale.y)
        {
            transform.localScale = naturalScale;
            contentCapsule.position = new Vector3(contentCapsuleNaturalPosition.x, contentCapsule.position.y, contentCapsuleNaturalPosition.z);
        }

        if (transform.localScale.x > naturalScale.x || transform.localScale.y > naturalScale.y)
            contentParent.horizontal = true;
        else
        {
            contentParent.horizontal = false;
            contentCapsule.position = new Vector3(contentCapsuleNaturalPosition.x, contentCapsule.position.y, contentCapsuleNaturalPosition.z);
        }

    }


    void Update()
    {
        
        /*
        if(shouldRunTimer)
        {
            timer += Time.deltaTime;
            if(timer > 0.5)
            {
                timer = 0;
                shouldRunTimer = false;
            }
        }
        */


        int fingersOnScreen  = 0;

        if (!canBeZoomed)
            return;

        foreach (Touch touch in Input.touches)
            {
                fingersOnScreen++; //Count fingers (or rather touches) on screen as you iterate through all screen touches.

            //You need two fingers on screen to pinch.
            if (fingersOnScreen == 2)
            {

                //First set the initial distance between fingers so you can compare.
                if (touch.phase == TouchPhase.Began)
                {
                    initialFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    initialScale = transform.localScale;
                }
                else
                {
                    float currentFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);

                    float scaleFactor = currentFingersDistance / initialFingersDistance;

                    transform.localScale = initialScale * scaleFactor;
                }

                if (touch.phase == TouchPhase.Ended)
                    initialFingersDistance = 0;
            }

            }

        ConstrainImageSize();
    }
}
