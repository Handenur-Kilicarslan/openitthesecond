using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numbers : MonoBehaviour
{
    public string number;
    public string correctNumber;
   
    public Animator anim;
    public Animator anim2;
    public Animator spinanim;
    public GameManager gm;
    public value vle;
    public Text text;
    public Text boxtext;
    public GameObject prize;

    bool won;

    private void Start()
    {
        correctNumber = Random.Range(1000, 9999).ToString();
        text.text = correctNumber.ToString();
        won = false;
    }

    private void Update()
    {
        boxtext.text = number;
        if (number == correctNumber && won != true)
        {
            prize.transform.parent = null;
            prize.transform.position = GameObject.Find("boxLocation").transform.position;
            anim.SetBool("open", true);
            StartCoroutine(_win());
            won = true;
        }
    }

    IEnumerator _win()
    {
        yield return new WaitForSeconds(1.5f);
        anim2.SetBool("win", true);
        yield return new WaitForSeconds(0.75f);
        spinanim.SetBool("win", true);
        yield return new WaitForSeconds(0.75f);
        gm.win(vle);

    }
}
