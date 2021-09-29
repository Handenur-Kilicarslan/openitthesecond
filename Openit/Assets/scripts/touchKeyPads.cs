using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchKeyPads : MonoBehaviour
{
	public string key;
	public numbers nmb;
	public void touch()
	{
		nmb.number += key;
		if (key == "C")
		{
			nmb.number = "";
		}
		if(key == "E")
		{
			nmb.number = nmb.number.Remove(nmb.number.Length - 2);
		}
	}
}
