using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  WeaponOnAirplane : MonoBehaviour
{
    //Место откуда стреляем
    [SerializeField] private Transform[] bulletSpawnPos;

    public Weapon[] AvailibleWeapons;
    private Weapon equipedWeapon;
    
    private float timer;

    private void Awake()
    {
        equipedWeapon = AvailibleWeapons[0];
    }

    private void FixedUpdate()
    {
        if(timer < equipedWeapon.shootRate)
        {
            timer += Time.fixedDeltaTime;
        }
    }

    public void Shoot()
    {
        if (timer >= equipedWeapon.shootRate)
        {
            equipedWeapon.Shoot(bulletSpawnPos);
            timer = 0;
        }
    }
}
