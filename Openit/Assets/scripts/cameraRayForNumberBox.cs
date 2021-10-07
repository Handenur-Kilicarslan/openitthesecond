using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRayForNumberBox : MonoBehaviour
{
    RaycastHit HitInfo;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out HitInfo, 100.0f) && HitInfo.collider.gameObject.tag == "piece" && Input.GetKeyDown("mouse 0") == true)
        {
            HitInfo.collider.GetComponent<touchKeyPads>().touch();
        }
    }
}
