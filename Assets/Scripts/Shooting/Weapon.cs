using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    public string weaponName = "New Weapon";
    public AudioClip shootSound;
    public float shootRate = 1f;

    public abstract void Shoot(Transform[] _bulletSpawn);
}
