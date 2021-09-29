using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRay : MonoBehaviour
{
  public bool used;
  public GameObject target;
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
      if (Physics.Raycast(ray, out HitInfo, 100.0f) && HitInfo.collider.gameObject.tag == "kapak" && Input.GetKeyDown("mouse 1") == true)

      {
        if (used == false)
      {
        gameObject.AddComponent<focusPuzzle>().target = target;
        if(target.GetComponentInChildren<rotateCase>() != null)
          target.GetComponentInChildren<rotateCase>().enabled = true;
        GetComponent<rotateCam>().enabled = false;
        used = true;
      }
    }
  }
}
