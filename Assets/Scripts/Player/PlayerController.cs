using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //karakter kontrol için gerekli olan nesneler
    public CharacterController controller;
    private Vector3 direction;

    //fiziki tanımlamalar
    public float speed = 8;
    public float jumpForce = 10;
    public float gravity = -20;
    //ground tanımları
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool ableToMakeADoubleJump = true;

    //animator nesnesi
    public Animator animator;
    public Transform model;

    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.gameOver)
        {
            //ölme animasyonu
            animator.SetTrigger("isDead");
            //disable the script
            this.enabled = false;
        }


        //sağa sola hareket ataması
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        //speedi set etme
        animator.SetFloat("speed", Mathf.Abs(hInput));
        //yere değdi mi
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        //isGrounded set etme
        animator.SetBool("isGrounded", isGrounded);
        //yer çekimi ve zıplama ayarı
        direction.y += gravity * Time.deltaTime ;
        //eğer yerdeyse
        if(isGrounded)
        {
            ableToMakeADoubleJump = true;
            //eğer zıplanma tuşuna basılmışsa
            if(Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            //eğer F tuşuna basılmışsa
            if(Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("fireBallAttack");
            }
        }
        else
        {
            if(ableToMakeADoubleJump & Input.GetButtonDown("Jump"))
            {
                DoubleJump();
            }
        }
        //fireball atarken hiç bişey yapmasın
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("FireBall Attack"))
        {
            return;
        }
        //yöne göre modelin yüzünü dönmesi
        if(hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }
        //move
        controller.Move(direction * Time.deltaTime);

        //karakter kaymasın diye
        if(transform.position.z != 0) transform.position = new Vector3(transform.position.x, transform.position.y, 0);



    }


    public void DoubleJump()
    {
        animator.SetTrigger("doubleJump");
        direction.y = jumpForce;
        ableToMakeADoubleJump = false;
    }

    public void Jump()
    {
        direction.y = jumpForce;
    }




}
