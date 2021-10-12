using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCam : MonoBehaviour
{
    public GameObject target;
    public DynamicJoystick joystick;
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, joystick.Horizontal * 150 * Time.deltaTime);
    }
}
