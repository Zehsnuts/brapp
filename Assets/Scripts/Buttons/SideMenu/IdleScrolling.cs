using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleScrolling : MonoBehaviour {

    public Transform scrollTarget;

    public float scrollSpeed, scrollAcceleration, maxSpeed;
    public int maxY, minY;

    public bool shouldScroll, shouldGoUp;

    void Awake()
    {
        scrollSpeed = 0;
        shouldScroll = true;
    }

    void Start()
    {
        StartAutoScroll();
    }

    public void StartAutoScroll()
    {
        StartCoroutine(RearmAutoScroll());
    }

    public void StopAutoScroll()
    {
        StopCoroutine(RearmAutoScroll());
        StartCoroutine(RearmAutoScroll(15));
    }

    void Update()
    {
        if (shouldScroll)
            ScrollEngine();
    }

    IEnumerator RearmAutoScroll(int seconds = 5)
    {
        shouldScroll = false;
        yield return new WaitForSeconds(seconds);
        shouldScroll = true;
    }

    void ScrollEngine()
    {
        if (scrollSpeed < maxSpeed)
            scrollSpeed += scrollAcceleration;

        float actualSpeed;
        if (shouldGoUp)
            actualSpeed = scrollSpeed;
        else
            actualSpeed = -scrollSpeed;

        scrollTarget.transform.position += new Vector3(0, actualSpeed * Time.deltaTime, 0);

        LimitPosition();
    }

    void LimitPosition()
    {
        //Debug.Log(scrollTarget.localPosition.y);
        if (scrollTarget.position.y >= maxY && shouldGoUp || !shouldGoUp && scrollTarget.position.y < minY)
            ReverseDirection();
    }

    void ReverseDirection()
    {
        Debug.Log("Change Direction");
        shouldGoUp = !shouldGoUp;
    }
}
