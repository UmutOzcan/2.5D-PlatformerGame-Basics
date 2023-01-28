using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;

    public float fireBallSpeed = 600;

    public void FireBallAttack()
    {
        GameObject ball = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        //topun ilerlemesi için rigid body ile yön ve hız belirleyerek kuvvet oluşturuyoruz
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);
    }
}


