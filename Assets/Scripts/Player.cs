using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    Rigidbody2D rb2D;

    public GameObject groundCheck;

    public GameObject c1, c2;
    public GameObject playerWeapon1, playerWeapon2;

    private GameObject bullet;
    public GameObject bulletSpawner;
    public float bulletForce;

    public bool grounded;

    int characterChanger;

 //   public Image LoadingBar;

    public Animator animator1;
    public Animator animator2;


    void Start()
    {
        characterChanger = 1;
        //c1 = GameObject.Find("Player/c1");
        //c2 = GameObject.Find("Player/c2");
        rb2D = GetComponent<Rigidbody2D>();
        animator1 = GetComponentInChildren<Animator>();
        animator2 = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        PlayerChangeCharacter();
        
        if (characterChanger == 1)
        {
            c1.SetActive(true);
            c2.SetActive(false);

            bullet = playerWeapon1;

            float newLocalScale = 1.2f;
            transform.localScale = new Vector2(newLocalScale, newLocalScale);
            PlayerChangeDirection(newLocalScale);

            rb2D.isKinematic = false;

            PlayerWalk();
            
            PlayerJump();
        }

        else if (characterChanger == 2)
        {
            c1.SetActive(false);
            c2.SetActive(true);

            bullet = null;

            //   spriteRenderer.sprite = character2;
            float newLocalScale = 0.5f;
            transform.localScale = new Vector2(newLocalScale, newLocalScale);
            PlayerChangeDirection(newLocalScale);

            rb2D.isKinematic = true;

            PlayerFly();
        }

        PlayerAttack();
    }

    private void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject ammo = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
            Vector2 bulletDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletSpawner.transform.position;

          //   Camera.main.ScreenToWorldPoint(Input.mousePosition)
            ammo.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletForce * Time.deltaTime, ForceMode2D.Impulse);

            Destroy(ammo, 2);
        }
    }

    public void PlayerChangeCharacter()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (characterChanger == 1)
            {
                characterChanger = 2;
            }
            else if (characterChanger == 2)
            {
                characterChanger = 1;
            }
        }
    }

    private void PlayerFly()
    {
       // animator2.SetTrigger("PlayerFly");

        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontal, vertical, 0));
    }


    private void PlayerWalk()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator1.SetTrigger("PlayerWalk");
            float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            transform.Translate(new Vector2(horizontal, 0));
        }
        else
        {
            animator1.SetTrigger("PlayerIdle");
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator1.SetTrigger("PlayerJump");
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void PlayerChangeDirection(float newLocalScale)
    {
        float absLocalScale = Mathf.Abs(newLocalScale);

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector2(absLocalScale, absLocalScale); 
        }

        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector2(-absLocalScale, absLocalScale);
        }
    }

}

