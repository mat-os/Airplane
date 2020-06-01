using System;
using UnityEngine;

[RequireComponent(typeof(Airplane))]
[RequireComponent(typeof(InputReader))]
public class Player : MonoBehaviour
{
    [SerializeField] private Airplane airplane;
    [SerializeField] private InputReader inputReader;
    
    //Визуальный эффект для буста
    [SerializeField] private GameObject boostEffect;

    private void Awake()
    {
        IDriver driver = new HumanDriver();
        airplane.SetDriver(driver);
        airplane.StartEngine();
    }

    private void FixedUpdate()
    {
        if (Math.Abs(inputReader.ReadDirectionInput().x) > 0)
        {
            airplane.ControlRoll(inputReader.ReadDirectionInput().x);
        }        
        
        if (Math.Abs(inputReader.ReadDirectionInput().y) > 0)
        {
            airplane.ControlThrust(inputReader.ReadDirectionInput().y);
        }

        if (inputReader.ReadShoot())
        {
            airplane.Shoot();
        }

        if (inputReader.ReadBoost())
        {
            airplane.Boost();
            boostEffect.SetActive(true);

            EffectController.Instance.ChangeCamFOV(true);
        }
        else
        {
            boostEffect.SetActive(false);
            
            EffectController.Instance.ChangeCamFOV(false);
        }
    }
}