﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform BulletPosition;
    public GameObject Bullet;
    public float BulletSpeed = 2.0f;
    public float fireRate = 0.2f;
    float nextFire = 0.0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject Bul = Instantiate(Bullet, BulletPosition.position, BulletPosition.rotation);
        Rigidbody2D rb = Bul.GetComponent<Rigidbody2D>();

        rb.AddForce(BulletPosition.up * BulletSpeed, ForceMode2D.Impulse);
    }
}
