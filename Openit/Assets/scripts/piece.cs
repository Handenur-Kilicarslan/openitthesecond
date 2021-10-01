using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piece : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public Vector3 movement;
    public float speed = 100f;

    public float x = 100f;

    // Start is called before the first frame update
    void Start()
    {
        //myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        movement = new Vector3(x, 0, 0);
        myRigidbody.AddForce(movement);
        */

        /*movementi kodla
        movement = new Vector3(x, 0, 0);
        myRigidbody.AddForce(movement);

        if (Input.GetAxis("Mouse X") < 0)
        {
            Debug.Log("sağa mı bacım");
            myRigidbody.AddForce(movement);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            myRigidbody.AddForce(-movement);
        }
        
    */
    }


}
