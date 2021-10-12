using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPuzzle1 : MonoBehaviour
{
    public bool used;

    GameObject cam;
    private void Start()
    {
        used = false;
    }
    private void OnMouseDrag()
    {
        if (used == false)
        {
            cam = GameObject.FindWithTag("cam");
            cam.AddComponent<focusPuzzle>().target = this.gameObject;
            cam.GetComponent<rotateCam>().enabled = false;
            used = true;
        }
    }
}
