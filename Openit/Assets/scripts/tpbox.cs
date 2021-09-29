using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpbox : MonoBehaviour
{
  // Update is called once per frame
  void Update()
  {
    transform.position = Vector3.Lerp(transform.position,GameObject.Find("boxLocation").transform.position, 0.03f);
  }
}
