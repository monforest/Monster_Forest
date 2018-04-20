using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//This script Control whole game, control UI and manage the Scene

public class GameControl : MonoBehaviour {

    public static GameControl gameControl;

    public GameObject WinPopup;
    public GameObject LosePopup;

    public bool isPlayerDead = false;
    public bool isEnemyBossDead = false;

    //public GameObject player;
    PlayerPickup playerStats;

    public GameObject gameOverText; //UI
    
    public Text goldCount;
    public Text crystalCount;

    public bool gameOver = false;

    public float scrollSpeed = -0.5f;   //Background scrolling speed(NOT mid ground) 

   
    void Awake()
    {
        if(gameControl == null)
        {
            gameControl = this;
        }
        if(gameControl != this)
        {
            Destroy(gameObject);
        }       
    }

    void Start()
    {
     //   DontDestroyOnLoad(this);
     
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickup>();
    }

	// Update is called once per frame
	void Update ()
    {
        //if (gameOver)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        goldCount.text = "Gold: " + playerStats.numberOfGold;
        crystalCount.text = "Crystal: " + playerStats.numberOfCrystal;

        if (isPlayerDead) 
        {
            LosePopup.SetActive(true);
        }

        if (isEnemyBossDead && playerStats.numberOfCrystal >= 12)
        {
            WinPopup.SetActive(true);
        }
    }

    public void LoadingGamePlay()
    {
        gameOver = true;
        GameReset();
        SceneManager.LoadScene(1);
    }

    private void GameReset()
    {
        isPlayerDead = false;
        isEnemyBossDead = false;
        playerStats.numberOfCrystal = 0;
        playerStats.numberOfGold = 0;
        WinPopup.SetActive(false);
        LosePopup.SetActive(false);
    }

    public void QuitGamePlay()
    {
        Application.Quit();
    }
    
}
