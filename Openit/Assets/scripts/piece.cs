using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piece : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public Vector3 movement;
    public float speed = 100f;

    public float x = 100f;
    public int foo = 1;

   
    private void OnMouseDrag()
    {
        //Debug.Log(name + "was clicked");
        //Debug.Log(transform.position);
        if(gameObject.tag == "puzzlePiece")
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) //sol tık yaptıysak
        {
            speed = 100f;
        }

        Debug.Log(foo);
    }
}
