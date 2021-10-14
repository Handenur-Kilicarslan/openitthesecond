using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoxes : MonoBehaviour
{
    public GameObject[] boxes;
    public GameObject[] prizes;
    public DynamicJoystick joystick;
    public GameObject vc1;
    public GameObject vc2;
    public GameManager gm;

    GameObject box;
    GameObject prize;

    void Start()
    {
        for (int i = 3; i > 0; i--)
        {
            box = Instantiate(boxes[Random.Range(0, boxes.Length)],
                                                 transform.position + Vector3.up * 5f + Vector3.right * i * Random.Range(1, 2f) + Vector3.forward * i * Random.Range(1, 2f),
                                                 Quaternion.Euler(Vector3.one * Random.Range(0, 180)));
            box.AddComponent<Rigidbody>();
            box.AddComponent<TPtoboxLocation>();
            box.GetComponent<TPtoboxLocation>().vc1 = vc1;
            box.GetComponent<TPtoboxLocation>().vc2 = vc2;
            prize = Instantiate(prizes[Random.Range(0, prizes.Length)], box.transform);

            if (box.GetComponentInChildren<rotateCase>() != null)
            {
                box.GetComponentInChildren<rotateCase>().joystick = joystick;
                box.GetComponentInChildren<rotateCase>().enabled = false;
                box.GetComponentInChildren<rotateCase>().gm = gm;
                box.GetComponentInChildren<rotateCase>().prize = prize;
                box.GetComponentInChildren<rotateCase>().spinanim = prize.GetComponent<Animator>();
                box.GetComponentInChildren<rotateCase>().vle = prize.GetComponent<Value>();
            }
            if (box.GetComponentInChildren<numbers>() != null)
            {
                box.GetComponentInChildren<numbers>().gm = gm;
                box.GetComponentInChildren<numbers>().prize = prize;
                box.GetComponentInChildren<numbers>().spinanim = prize.GetComponent<Animator>();
                box.GetComponentInChildren<numbers>().vle = prize.GetComponent<Value>();

            }
        }
    }
}
