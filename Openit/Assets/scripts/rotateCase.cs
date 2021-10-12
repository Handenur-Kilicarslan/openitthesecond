using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCase : MonoBehaviour
{
    public DynamicJoystick joystick;
    public Animator anim;
    public Animator anim2;
    public Animator spinanim;
    public GameManager gm;
    public value vle;
    public GameObject prize;

    bool won;

    private void Start()
    {
        won = false;
        won = false;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Mathf.Abs(joystick.Horizontal) * 5f));



        if (transform.rotation.z >= 0.9 && won != true)
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
        gm.Win(vle);
    }
}
