using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRay : MonoBehaviour
{
    public bool used;
    public GameObject target;
    public DynamicJoystick joystick; 
    RaycastHit HitInfo;


    // Start is called before the first frame update
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out HitInfo, 100.0f) && 
            HitInfo.collider.gameObject.tag != null  &&
            joystick.Vertical > 0)

        {
            if(HitInfo.collider.gameObject.tag == "kapak") { 
                if (used == false)
                {
                    gameObject.AddComponent<focusPuzzle>().target = target;
                    gameObject.GetComponent<focusPuzzle>().joystick = joystick;
                    if (target.GetComponentInChildren<rotateCase>() != null)
                        target.GetComponentInChildren<rotateCase>().enabled = true;
                    GetComponent<rotateCam>().enabled = false;
                    used = true;
                }
        }
    }
    }
}
