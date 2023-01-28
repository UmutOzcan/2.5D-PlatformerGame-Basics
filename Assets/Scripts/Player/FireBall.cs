using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject damageEffect;
    public int damageAmount = 40;

    //eğer trigger edilen tag enemy ise belirlenen yerde ve yönde damageeffect yap ve nesneyi yok et
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy")
        {
            //girilen yerde girilen rotada girilen effect i yarat
            Instantiate(damageEffect, transform.position, damageEffect.transform.rotation);
            //diğer componentten takedamage methodunu çağırdık
            other.GetComponent<Enemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

}

