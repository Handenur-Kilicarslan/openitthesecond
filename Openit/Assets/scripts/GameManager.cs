using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    public Text textMoney;
    public GameObject winpanel;
    public Animator winpanelanim;
    public ParticleSystem confetti;
    public GameObject joyStick;
    public Text priceTxt;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        textMoney.text = money.ToString();

    }

    public void NextLevel()
    {
        Debug.Log("Next Level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void win(value vle)
    {
        winpanel.SetActive(true);
        winpanelanim.SetBool("win", true);
        confetti.Play();

        joyStick.SetActive(false);


        money += vle.mvalue;

        priceTxt.text = vle.mvalue.ToString();

        PlayerPrefs.SetInt("money", money);
        textMoney.text = money.ToString();

    }
}
