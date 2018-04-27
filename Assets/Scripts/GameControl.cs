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

    public int totalEnemyinScene;
    public int numberEnemyAlive;

    GameObject[] enemies;

    PlayerStats playerStats;

    public GameObject gameOverText; //UI

    public Text crystalCount;
    public Text enemyKilled;

    public bool gameOver = false;

    public float scrollSpeed = -0.5f;   //Background scrolling speed


    void Awake()
    {
        if (gameControl == null)
        {
            gameControl = this;
        }
        if (gameControl != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //   DontDestroyOnLoad(this);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemyinScene = enemies.Length;

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        isPlayerDead = playerStats.isDead;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        numberEnemyAlive = enemies.Length;

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        crystalCount.text = "Crystal: " + playerStats.numberOfCrystal;
        int countDeadEnemies = totalEnemyinScene - numberEnemyAlive;
        enemyKilled.text = "Count enemies: " + countDeadEnemies;

        if (isPlayerDead)
        {
            LosePopup.SetActive(true);
        }

        if (isEnemyBossDead && playerStats.numberOfCrystal >= 12)
        {
            WinPopup.SetActive(true);
        }
    }

    public void StartGamePlay()
    {
        SceneManager.LoadScene(1);
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
        playerStats.currentHealth = playerStats.maxHealth;
        WinPopup.SetActive(false);
        LosePopup.SetActive(false);
    }

    public void QuitGamePlay()
    {
        Application.Quit();
    }
    
}
