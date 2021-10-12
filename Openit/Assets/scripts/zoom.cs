using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    public DynamicJoystick joystick;
    public GameObject target;

    Vector3 targetPosition;
    Vector3 mainPosition;

    // Start is called before the first frame update
    void Start()
    {
        mainPosition = transform.position;
        targetPosition = target.transform.position + target.transform.forward * 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.Vertical > 0f)
        {

        }
        if (joystick.Vertical < 0f)
        {

        }
    }
}
