using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [Header("Boost Setting")]
    [SerializeField] private float BoostForce;

    [Header("Maneuverability Settings")]
    [SerializeField] private float thrustForce;
    [SerializeField] private float tiltForce;
    
    [Header("Speed Settings")]
    [SerializeField] private float basicForce;
    [SerializeField] private float maxVelocity;
    
    [Header("WeaponSetting")]
    [SerializeField] private WeaponOnAirplane weaponOnAirplane;

    private IDriver driver;
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    public void SetDriver(IDriver _driver)
    {
        driver = _driver;
    }

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        if (weaponOnAirplane == null)
        {
            weaponOnAirplane = GetComponent<WeaponOnAirplane>();
        }
    }

    private void FixedUpdate()
    {
        ApplyConstSpeed();
    }
    public void StartEngine()
    {
        driver.Control(this);
    }

    //Управляем тангажом
    public void ControlThrust(float _thrustDir)
    {
        rb.AddRelativeTorque(Vector3.right* (_thrustDir * thrustForce));
    }

    //управляем креном
    public void ControlRoll(float _rollDir)
    {
        rb.AddRelativeTorque(Vector3.forward * (_rollDir * tiltForce ));
    }

    //управляем ускорением
    public void Boost()
    {
        rb.AddRelativeForce(BoostForce * Vector3.forward);
    }
    
    private void ApplyConstSpeed()
    {
        if (rb.velocity.magnitude < maxVelocity)
        {
            rb.AddRelativeForce(basicForce * Vector3.forward);
        }
    }
    
    public void Shoot()
    {
        weaponOnAirplane.Shoot();
    }
}
