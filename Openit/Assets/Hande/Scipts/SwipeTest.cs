using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//bunu görünmez player a koy

public class SwipeTest : MonoBehaviour
{
    //int n = 2; //dizi eleman sayısı
    bool[,] colorsArray = new bool[2, 2]; //dolu ise false boş yani müsaitse true


    public Swipe swipeControls;
    public Transform player;
    public Transform invisiblePlayer;
    public int desiredPosition = 1;

    //public Swiper swiper2;

    public bool canSwipe = false;

    private void Start()
    {
        invisiblePlayer.position = player.position;
        /*
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                colorsArray[i, j] = false;
            }
        }
        colorsArray[1, 1] = true; //en son yeri boş dizinin yani true
       
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                colorsArray[i, j] = true;
            }
        }
        colorsArray[0, 0] = false;
         */

    }


    private void Update()
    {
        if (swipeControls.SwipeLeft)  //2 swipe çalışmıyor ?
        {
            LeftSwp(invisiblePlayer);

            Debug.Log(canSwipe + " canswipe değeri");
            if (canSwipe == true)
            {
                StartCoroutine(WaitForSwipe());
                LeftSwp(player);
                canSwipe = false;
            }
        }
        if (swipeControls.SwipeRight)
        {
            StartCoroutine(RightSwpIE(invisiblePlayer));
            Debug.Log(canSwipe + " canswipe değeri");
            
            if (canSwipe == true)
            {
                StartCoroutine(WaitForSwipe());
                RightSwp(player); //
                canSwipe = false;
            }
        }
        if (swipeControls.SwipeUp)
        {
            UpSwp(invisiblePlayer);
            if (canSwipe == true)
            {
                StartCoroutine(WaitForSwipe()); 
                UpSwp(player);
                canSwipe = false;
            }
        }
        if (swipeControls.SwipeDown)
        {
            DownSwp(invisiblePlayer);
            if (canSwipe == true)
            {
                StartCoroutine(WaitForSwipe());
                DownSwp(player);
                canSwipe = false;
            }
        }
        
        //player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f * Time.deltaTime);
    }


    void LeftSwp(Transform player)
    {
        player.transform.DOMoveX(0, 0.5f);
    }

    void RightSwp(Transform player)
    {
        player.transform.DOMoveX(desiredPosition, 0.5f);
    }

    IEnumerator RightSwpIE(Transform player)
    {
        yield return new WaitForSeconds(0.1f);

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

    public IEnumerator WaitForSwipe()
    {
        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Empty")
        {
            Debug.Log(other.name + " is " + other.tag);

            other.gameObject.tag = "Full";

            canSwipe = true;
        }
    }
    //nce bool true snra hareke


}
