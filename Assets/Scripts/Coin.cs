using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // coin için dönme hızı
    public float rotationSpeed = 80;

    // Update is called once per frame
    void Update()
    {
        //transform nesnesi ile coin rotate
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    //coin ile player etkileşime girince ne olucak
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == ("Player"))
        {
            PlayerManager.numberOfCoins++;
            Destroy(gameObject);
        }
    }

}

