using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUIManager : MonoBehaviour
{
    [SerializeField] private Airplane playerAirplane;

    [SerializeField] private SpeedometrUIController speedometrUiController;
    
    [SerializeField] private SpeedometrUIController weaponUiController;
    
    private void Update()
    {
        speedometrUiController.UpdateSpeedometr(playerAirplane.Rb.velocity.magnitude);
    }
}
