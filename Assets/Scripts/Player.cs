using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    Rigidbody2D rb2D;

    public GameObject groundCheck;

    //public Sprite character1;
    //public Sprite character2;

    //SpriteRenderer spriteRenderer;

    public GameObject c1, c2;
    public GameObject bullet, bulletSpawner;
    public float bulletForce;

    public bool grounded;

    int characterChanger;

 //   public Image LoadingBar;

//    public Animation animator;


    void Start()
    {
     //   spriteRenderer = GetComponent<SpriteRenderer>();

        characterChanger = 1;
        //c1 = GameObject.Find("Player/c1");
        //c2 = GameObject.Find("Player/c2");
        rb2D = GetComponent<Rigidbody2D>();
        //   animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerChangeCharacter();

        PlayerChangeDirection();

        if (characterChanger == 1)
        {
            c1.SetActive(true);
            c2.SetActive(false);
            //spriteRenderer.sprite = character1;

            float newLocalScale = 1.2f;
            transform.localScale = new Vector2(newLocalScale, newLocalScale);

            rb2D.isKinematic = false;

            PlayerWalk();
            
            PlayerJump();
        }

        else if (characterChanger == 2)
        {
            c1.SetActive(false);
            c2.SetActive(true);

         //   spriteRenderer.sprite = character2;
            float newLocalScale = 0.5f;
            transform.localScale = new Vector2(newLocalScale, newLocalScale);
  
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
        //animator.SetTrigger("PlayerFly");

        float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(new Vector3(horizontal, vertical, 0));
    }

    private void PlayerWalk()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            //    animator.SetBool("Walk", true);
            float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            transform.Translate(new Vector2(horizontal, 0));
        }
        else
        {
          //  animator.SetBool("Walk", false);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //     animator.SetTrigger("Jump");
            rb2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void PlayerChangeDirection()
    {
        float absLocalScaleX = Mathf.Abs(transform.localScale.x);
        float absLocalScaleY = Mathf.Abs(transform.localScale.y);

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector2(absLocalScaleX, absLocalScaleY);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector2(-absLocalScaleY, absLocalScaleY);
        }
    }

}

