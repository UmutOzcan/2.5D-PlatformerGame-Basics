using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 5;
    public float speed = 5.5f;
    public float attackRange = 2;

    //enemy health
    public int health;
    public int maxHealth;

    //animator oluşturulur
    public Animator animator;


    // Start başladığında target player seçiliyor
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerManager.gameOver)
        {
            animator.enabled = false;
            this.enabled = false;
        }


        //enemy ve player arası uzaklık
        float distance = Vector3.Distance(transform.position, target.position);

        if(currentState == "IdleState")
        {
            if(distance < chaseRange)
            {
                currentState = "ChaseState";
            }  
        }
        else if(currentState == "ChaseState")
        {
            //run animasyonunu çağır ve attack yapmayı false yap
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if(distance < attackRange)//eğer mesafe atak rangeinden kısaysa saldır
            {
                currentState = "AttackState";
            }

            //playerın yönüne göre kovala
            if(target.position.x > transform.position.x)//player sağdaysa
            {
                //sağa doğru hareket et frame ve hız çarpımı kadar
                transform.Translate(transform.right * speed * Time.deltaTime);
                //düşmanın yüzünü dönmesi için rotation ysi 180 derece yapıldı
                transform.rotation = Quaternion.Euler(0,180,0);
            }
            else//ilginç bi şekilde transform.left yok * -1 yapıyoruz
            {
                //sola doğru hareket et frmae ve hız kadar
                transform.Translate(-transform.right * speed * Time.deltaTime);
                //düşmanın yüzünü dönmesi için rotation identity durumuna getirildi.
                transform.rotation = Quaternion.identity;
            }
        }
        else if(currentState == "AttackState")
        {
            animator.SetBool("isAttacking", true);

            if(distance > attackRange)//uzaklık atak rangeinden büyükse tekrar kovala
            {
                currentState = "ChaseState";
            }
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        //düşmana vurunca bize saldırması için state değiştirdik
        currentState = "ChaseState";

        if(health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //die animasyonu çalışması için trigger aktifleştirdik
        animator.SetTrigger("isDead");
        //ölme animasyonundan sonra colliderı kaldırdık
        GetComponent<CapsuleCollider>().enabled = false;

        Destroy(gameObject,3);

        //scripti kaldırdık
        this.enabled = false;

    }

}
