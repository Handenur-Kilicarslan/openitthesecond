using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Swiper : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;

    public int desiredPosition = 2;

    // Update is called once per frame
    void Update()
    {
        if (swipeControls.SwipeLeft)
        {
            LeftSwp(player);
        }
        if (swipeControls.SwipeRight)
        {
            RightSwp(player);
        }
        if (swipeControls.SwipeUp)
        {
            UpSwp(player);
        }
        if (swipeControls.SwipeDown)
        {
            DownSwp(player);
        }
        /*
                if (canSwipe)
                {
                    if (swipeControls.SwipeLeft)
                    {
                        LeftSwp(player);
                    }
                    if (swipeControls.SwipeRight)
                    {
                        RightSwp(player);
                    }
                    if (swipeControls.SwipeUp)
                    {
                        UpSwp(player);
                    }
                    if (swipeControls.SwipeDown)
                    {
                        DownSwp(player);
                    }
                    canSwipe = false;
                    invisiblePlayer.position = player.position;
                }
                */
    }


    void LeftSwp(Transform player)
    {
        player.transform.DOMoveX(0, 0.5f);
    }

    void RightSwp(Transform player)
    {
        player.transform.DOMoveX(desiredPosition, 0.5f);
    }

    void UpSwp(Transform player)
    {

        player.transform.DOMoveZ(0, 0.5f);
    }

    void DownSwp(Transform player)
    {
        player.transform.DOMoveZ(-desiredPosition, 0.5f);
    }
}

