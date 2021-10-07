using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinalSwipe : MonoBehaviour
{
    public Swipe swipeControls;
    public GameObject[] planes4;
    public GameObject[] players;
    public int desiredPosition = 2;

    void Update()
    {
        if (swipeControls.SwipeRight)
        {
            SwitchPlayerRight(planes4[0], planes4[1]);
            SwitchPlayerRight(planes4[2], planes4[3]);
        }
        if (swipeControls.SwipeLeft)
        {
            SwitchPlayerLeft(planes4[3], planes4[2]);
            SwitchPlayerLeft(planes4[1], planes4[0]);
        }
        if (swipeControls.SwipeDown)
        {
            SwitchPlayerDown(planes4[0], planes4[2]);
            SwitchPlayerDown(planes4[1], planes4[3]);
        }
        if (swipeControls.SwipeUp)
        {
            SwitchPlayerUp(planes4[2], planes4[0]);
            SwitchPlayerUp(planes4[3], planes4[1]);
        }
        
        DidYouWin(planes4);

    }

    void SwitchPlayerRight(GameObject planeSource, GameObject planeDestination)
    {
        GameObject tempPlayer1;

        if (planeSource.gameObject.tag == "Full" && planeDestination.gameObject.tag == "Empty")
        {
            tempPlayer1 = planeSource.GetComponent<PlaneInfo>().playerPiece;
            RightSwp(tempPlayer1.transform);
            planeSource.gameObject.tag = "Empty";
            planeDestination.gameObject.tag = "Full";
            planeDestination.GetComponent<PlaneInfo>().playerPiece = tempPlayer1;
        }
    }
    void SwitchPlayerLeft(GameObject planeSource, GameObject planeDestination)
    {
        GameObject tempPlayer1;

        if (planeSource.gameObject.tag == "Full" && planeDestination.gameObject.tag == "Empty")
        {
            tempPlayer1 = planeSource.GetComponent<PlaneInfo>().playerPiece;
            LeftSwp(tempPlayer1.transform);
            planeSource.gameObject.tag = "Empty";
            planeDestination.gameObject.tag = "Full";
            planeDestination.GetComponent<PlaneInfo>().playerPiece = tempPlayer1;
        }
    }
    void SwitchPlayerDown(GameObject planeSource, GameObject planeDestination)
    {
        GameObject tempPlayer1;

        if (planeSource.gameObject.tag == "Full" && planeDestination.gameObject.tag == "Empty")
        {
            tempPlayer1 = planeSource.GetComponent<PlaneInfo>().playerPiece;
            DownSwp(tempPlayer1.transform);
            planeSource.gameObject.tag = "Empty";
            planeDestination.gameObject.tag = "Full";
            planeDestination.GetComponent<PlaneInfo>().playerPiece = tempPlayer1;
        }
    }
    void SwitchPlayerUp(GameObject planeSource, GameObject planeDestination)
    {
        GameObject tempPlayer1;

        if (planeSource.gameObject.tag == "Full" && planeDestination.gameObject.tag == "Empty")
        {
            tempPlayer1 = planeSource.GetComponent<PlaneInfo>().playerPiece;
            UpSwp(tempPlayer1.transform);
            planeSource.gameObject.tag = "Empty";
            planeDestination.gameObject.tag = "Full";
            planeDestination.GetComponent<PlaneInfo>().playerPiece = tempPlayer1;
        }
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
    void DidYouWin(GameObject[] planes)
    {
        int winNumber = 1;
        //GameObject tempPlayer;
        for (int i = 0; i < 4; i++)
        {
            //tempPlayer = planes[i].GetComponent<PlaneInfo>().playerPiece;
            if (planes[i].GetComponent<PlaneInfo>().playerPiece.GetComponent<PlayerInfo>().whichColor == planes[i].GetComponent<PlaneInfo>().whichColor)
            {
                winNumber++;

                Debug.Log("Win Number " + winNumber);
            }

        }
        if (winNumber == 4)
        {
            Debug.Log("KIZIM SEN BU İŞİ ÇÖZMÜŞSÜN");
            //BURDA DA KUTU AÇILACAK
        }
    }

}
