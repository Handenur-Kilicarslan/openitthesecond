using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPtoboxLocation : MonoBehaviour
{
  public GameObject vc1;
  public GameObject vc2;

  private void OnMouseDown()
	{
    transform.rotation = Quaternion.identity;
    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    this.gameObject.AddComponent<tpbox>();
    Destroy(this.GetComponent<tpbox>(), 5f);
    vc1.SetActive(false);
    vc2.SetActive(true);
    vc2.GetComponent<cameraRay>().target = this.gameObject;
    if(gameObject.tag == "case2")
		{
      vc2.AddComponent<cameraRayForNumberBox>();
		}
    Destroy(this);
  }
}
