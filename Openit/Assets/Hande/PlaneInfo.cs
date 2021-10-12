using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WhichColor { Green, Red, Yellow, Blue, NoColor };

public class PlaneInfo : MonoBehaviour
{
    public bool isEmpty = false;
    public GameObject playerPiece;
    public WhichColor whichColor;
}
