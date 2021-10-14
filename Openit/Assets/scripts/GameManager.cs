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
    private GameObject gameArea;

    [Header("Exp. Panels")]
    public GameObject PlayingPanel;
    public GameObject startPanel;
    public GameObject swipeLeftPanel;
    public GameObject swipeUpPanel;


    [Header("Level Info")]
    public int money;
    public Text textMoney;
    public GameObject winpanel;
    public Animator winpanelanim;
    public ParticleSystem confetti;
    public Text allMoney;

    private GameObject joyStick;
    private GameObject joystickInScene;
    private GameObject buCanvas; //komple canvas kapıyorum haydi bakalım

    private float timeLapse = 0;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Debug.Log("Şu Leveldesiniz: " + whichLevel);
        if (whichLevel == 0)
        {
            StartCoroutine(StartThePanel());
            // StartThePanel();

        }
        money = PlayerPrefs.GetInt("money");
        allMoney.text = money.ToString();

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


                joystickInScene = gameArea.transform.GetChild(0).transform.GetChild(0).gameObject;


                buCanvas = gameArea.transform.GetChild(0).gameObject;



                gameArea.GetComponentInChildren<DropBoxes>().gm = this;


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

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void Win(Value vle)
    {
        Debug.Log("working");

        GameObject.FindGameObjectWithTag("joystick").SetActive(false);

        winpanel.SetActive(true);

        buCanvas.SetActive(false);

        winpanelanim.SetBool("win", true);
        confetti.Play();

        joystickInScene.SetActive(false);


        textMoney.text = vle.mvalue.ToString();
        money += vle.mvalue;


        PlayerPrefs.SetInt("money", money);

        allMoney.text = money.ToString();

    }

    IEnumerator StartThePanel()
    {

        PlayingPanel.SetActive(false);

        startPanel.SetActive(true);

        yield return new WaitForSeconds(5f);

        startPanel.GetComponent<Animation>().enabled = true;

        yield return new WaitForSeconds(1f);

        startPanel.SetActive(false);
        PlayingPanel.SetActive(true);
    }


    /* public void StartThePanel()
     {

         PlayingPanel.SetActive(false);

         startPanel.SetActive(true);

         if (timeLapse >= 4)
         {
             startPanel.GetComponent<Animation>().enabled = true;
         }
         if (timeLapse >= 6)
         {
             startPanel.SetActive(false);
         }

         PlayingPanel.SetActive(true);
     }
     */

}
