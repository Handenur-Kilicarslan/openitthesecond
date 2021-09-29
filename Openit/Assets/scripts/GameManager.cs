using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  // Start is called before the first frame update
  public int money;
  public Text text;
  public GameObject winpanel;
  public Animator winpanelanim;

  void Start()
  {
    money = PlayerPrefs.GetInt("money");
    text.text = money.ToString();
  }

  // Update is called once per frame
  void Update()
  {
        
  }

	public void win(value vle)
  {
    winpanel.SetActive(true);
    winpanelanim.SetBool("win", true);

    money += vle.mvalue;
    PlayerPrefs.SetInt("money", money);
    text.text = money.ToString();
  }
}
