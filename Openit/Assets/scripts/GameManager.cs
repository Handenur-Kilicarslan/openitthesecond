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
    public ParticleSystem confetti;

    public Text priceTxt;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        text.text = money.ToString();
        
    }

    public void win(value vle)
    {
        winpanel.SetActive(true);
        winpanelanim.SetBool("win", true);
        confetti.Play();

        money += vle.mvalue;

        priceTxt.text = vle.mvalue.ToString() + " $";

        PlayerPrefs.SetInt("money", money);
        text.text = money.ToString();
    }
}
