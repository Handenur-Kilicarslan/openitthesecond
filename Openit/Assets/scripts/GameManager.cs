using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Single Scene Data")]
    public Levels[] levels;
    public GameStatus status = GameStatus.empty;
    public int whichLevel = 0;

    public GameObject gameArea;

    [Header("Level Info")]
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

    void Update()
    {
        switch (status)
        {
            case GameStatus.empty:
                whichLevel = PlayerPrefs.GetInt("whichLevel");

                if (PlayerPrefs.GetInt("randomLevel") > 0)
                {
                    whichLevel = Random.Range(0, levels.Length);
                }

                gameArea = Instantiate(levels[whichLevel].LevelObj, new Vector3(-1.57f, -2.3f, -8.6f), Quaternion.identity);
                
                status = GameStatus.initalize;


                break;
            case GameStatus.initalize:
                break;
            case GameStatus.start:
                break;
            case GameStatus.stay:
                break;
            case GameStatus.restart:
                break;
            case GameStatus.next:
                break;
        }
    }


    public void NextLevel()
    {
        whichLevel++;
        PlayerPrefs.SetInt("whichLevel", whichLevel);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        /*buildIndex'i tutturuyotuz.
         * Olası farklı senaryolarda -next level olmayışı gibi- sıkıntı çıkarmasın diye */

        //iceCubeCount = 0;// next level için küp sayısını 0'ladım.
        status = GameStatus.empty; // tekrar empty'e çekiyoruz.

        if (whichLevel >= levels.Length)
        {
            whichLevel--;
            PlayerPrefs.SetInt("randomLevel", 1);
        }
    }

    public void Win(value vle)
    {
        Debug.Log("Bakalım Burası çalışıyor mu");

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
