using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focusPuzzle : MonoBehaviour
{
    public GameObject target;
  public DynamicJoystick joystick;

    GameObject main;
    Vector3 targetPosition;
    Vector3 mainPosition;
    void Start()
    {
        main = this.GetComponent<CinemachineVirtualCamera>().LookAt.gameObject;
        this.GetComponent<CinemachineVirtualCamera>().LookAt = target.transform;

        mainPosition = transform.position;
        targetPosition = target.transform.position + target.transform.forward * 4f;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.01f);
        if (joystick != null && joystick.Horizontal < 0)
        {
            GameObject.FindWithTag("cam").GetComponent<rotateCam>().enabled = true;
            targetPosition = mainPosition;
            this.GetComponent<CinemachineVirtualCamera>().LookAt = main.transform;
            GetComponent<cameraRay>().used = false;
            if (target.GetComponentInChildren<rotateCase>() != null)
                target.GetComponentInChildren<rotateCase>().enabled = false;
            Destroy(this, 3f);
        }
    }

  
}
