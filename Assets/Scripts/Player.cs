using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public Slider slider;

    public float moveSpeed;

    public float jumpForce;

    public Rigidbody2D rb2d;

    public Image LoadingBar;
    public float switchingTimer = 4f;

//    public Animation animator;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //   animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        PlayerWalk();

        PlayerChangeDirection();

        PlayerJump();

    //    TakeDamage();

     //   LoadingBar.fillAmount = 100;

    }
    private void TakeDamage()
    {
        currentHealth--;
        slider.value = currentHealth;
    }

    private void PlayerWalk()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
        //    animator.SetBool("Walk", true);
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0));
        }
        else
        {
          //  animator.SetBool("Walk", false);
        }
    }


    private void PlayerChangeDirection()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
       //     animator.SetTrigger("Jump");
            rb2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    //private void OnTriggerEnter2D (Collider2D other)
    //{
    //
    //  if(other.tag == "Bullet") 
    //  {
    //      Invoke("GetDamage ")
    //  }
    //
    //}
}
